namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.Dto.Import;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			StringBuilder sb = new StringBuilder();
			var games = JsonConvert.DeserializeObject<GameDto[]>(jsonString);
			
			foreach ( var game in games ) 
			{
				if (!IsValid(game) || 
					string.IsNullOrEmpty(game.Name) ||
					game.Tags.Count()==0 ||
					game.ReleaseDate==null ||
					game.Genre==null ||
					game.Developer==null
					)

				{
					sb.AppendLine("Invalid Data");
					continue;
				}

				var developer = context.Developers.FirstOrDefault(x => x.Name == game.Developer) ?? new Developer() { Name = game.Developer };
				var genre = context.Genres.FirstOrDefault(x=>x.Name == game.Genre) ?? new Genre() { Name = game.Genre };

				var validGame = new Game()
				{
					Developer = developer,
					Genre = genre,
					Name = game.Name,
					ReleaseDate = game.ReleaseDate.Value,
				};

                foreach (var tagGame in game.Tags)
                {
                    var tag = context.Tags.FirstOrDefault(x => x.Name == tagGame) ?? new Tag() { Name = tagGame };
					validGame.GameTags.Add(new GameTag { Game= validGame, Tag= tag });	
                }
                context.Games.AddRange(validGame);
                context.SaveChanges();
                sb.AppendLine($"Added {validGame.Name} ({validGame.Genre.Name}) with {validGame.GameTags.Count} tags");
			}
			
            return sb.ToString().Trim();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			StringBuilder sb = new StringBuilder();
			var users = JsonConvert.DeserializeObject<UserDto[]>(jsonString);
			foreach (var user in users)
			{
				if (!IsValid(user))
				{
					sb.AppendLine("Invalid Data");
					continue;
				}

				List<Card> validCards = new List<Card>();
				foreach (var card in user.Cards)
				{
					if (!IsValid(card))
					{
                        sb.AppendLine("Invalid Data");
                        continue;
                    }
					var validCard = new Card()
					{
						Number = card.Number,
						Cvc = card.CVC,
					};
					validCards.Add(validCard);
				}

				var validUser = new User()
				{
					FullName = user.FullName,
					Age = user.Age,
					Username = user.Username,
					Email = user.Email,
					Cards = validCards
				};
				sb.AppendLine($"Imported {validUser.Username} with {validUser.Cards.Count} cards"!);
				context.Users.Add(validUser);
			}

			context.SaveChanges();
			return sb.ToString().Trim();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			StringBuilder sb = new StringBuilder();
			var xml = new XmlSerializer(typeof(PurchaseDto[]), new XmlRootAttribute("Purchases"));
			StringReader reader = new StringReader(xmlString);
			var purchases = (PurchaseDto[])xml.Deserialize(reader);
			
			foreach (var purchase in purchases)
			{
				if (!IsValid(purchase))
				{
					sb.AppendLine("Invalid Data");
					continue;
				}
				var validPurchase = new Purchase()
				{
					Game = context.Games.FirstOrDefault(x => x.Name == purchase.GameName) ?? new Game() { Name = purchase.GameName },
					Type = purchase.Type.Value,
					ProductKey = purchase.ProductKey,
					Date = DateTime.ParseExact(purchase.Date,"dd/MM/yyyy HH:mm",CultureInfo.InvariantCulture),
					Card = context.Cards.FirstOrDefault(x=>x.Number==purchase.CardNumber),
				};
				context.Purchases.Add(validPurchase);
				sb.AppendLine($"Imported {validPurchase.Game.Name} for {validPurchase.Card.User.Username}");
			}

			context.SaveChanges();
			return sb.ToString().Trim();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}