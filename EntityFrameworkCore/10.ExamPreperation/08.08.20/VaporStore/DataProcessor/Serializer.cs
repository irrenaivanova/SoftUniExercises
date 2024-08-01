namespace VaporStore.DataProcessor
{
	using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
			var genres = context.Genres.ToList().Where(x => genreNames.Contains(x.Name))
				.Select(x => new GenreExport()
				{
					Id = x.Id,
					Genre = x.Name,
					Games = x.Games.Where(x=>x.Purchases.Count()>0).Select(x => new GameExport()
					{
						Id = x.Id,
						Title = x.Name,
						Developer = x.Developer.Name,
						Tags = string.Join(", ", x.GameTags.Select(x => x.Tag.Name)),
						Players = x.Purchases.Count()
					}).OrderByDescending(x => x.Players).ThenBy(x => x.Id).ToList(),

                    TotalPlayers = x.Games.Sum(x => x.Purchases.Count()),
                }).OrderByDescending(x => x.TotalPlayers).ThenBy(x => x.Id).ToList();
			return JsonConvert.SerializeObject(genres,Formatting.Indented);
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
			var users = context.Users.ToList()
				.Where(x => x.Cards.Any(x => x.Purchases.Any(x=>x.Type.ToString()==storeType)))
				.Select(x => new User1()
				{
					UserName = x.Username,
                    TotalSpent = x.Cards.Sum(
						x => x.Purchases.Where(p=>p.Type.ToString()==storeType)
						.Sum(p => p.Game.Price)),

                    Purchases = x.Cards.SelectMany(y => y.Purchases)
						.Where(x => x.Type.ToString() == storeType)
						.Select(p => new Purchase1()
					{
						CardNumber = p.Card.Number,
						Cvc = p.Card.Cvc,
						Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
						Game = new Game1()
						{
							GameName = p.Game.Name,
							GenreName = p.Game.Genre.Name,
							Price = p.Game.Price,
						}
					}).OrderBy(x => x.Date).ToArray(),
					
				}).OrderByDescending(x => x.TotalSpent).ThenBy(x => x.UserName).ToArray();

			var xml = new XmlSerializer(typeof(User1[]), new XmlRootAttribute("Users"));
			StringWriter writer = new StringWriter();
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);
            xml.Serialize(writer,users,ns);
			return writer.ToString();

		}
	}
}

//var data = context.Users.ToList()
//            .Where(x => x.Cards.Any(c => c.Purchases.Any(p => p.Type.ToString() == storeType)))
//            .Select(x => new UserXmlExportModel
//            {
//                Username = x.Username,
//                TotalSpent = x.Cards.Sum(
//                    c => c.Purchases.Where(p => p.Type.ToString() == storeType)
//                          .Sum(p => p.Game.Price)),
//                Purchases = x.Cards.SelectMany(c => c.Purchases)
//                    .Where(p => p.Type.ToString() == storeType)
//                    .Select(p => new PurchaseXmlExportModel
//                    {
//                        Card = p.Card.Number,
//                        Cvc = p.Card.Cvc,
//                        Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
//                        Game = new GameXmlExportModel
//                        {
//                            Title = p.Game.Name,
//                            Price = p.Game.Price,
//                            Genre = p.Game.Genre.Name,
//                        }
//                    })
//                    .OrderBy(x => x.Date)
//                    .ToArray()
//            })
//            .OrderByDescending(x => x.TotalSpent).ThenBy(x => x.Username).ToArray();