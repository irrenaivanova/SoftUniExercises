namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            Console.WriteLine(ExportSongsAboveDuration(context,4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new();
            var albums = context.Albums
                .Where(x => x.ProducerId == producerId)
                .Select(x => new
                {
                    ProducerName = x.Producer.Name,
                    x.ReleaseDate,
                    x.Name,
                    Songs = x.Songs.Select(x => new { x.Name, x.Price, WriterName = x.Writer.Name}),
                    AlbumPrice = x.Songs.Sum(x=>x.Price)
                }).ToList();
           
            foreach (var al in albums.OrderByDescending(x=>x.AlbumPrice))
            {
                sb.AppendLine($"-AlbumName: {al.Name}");
                sb.AppendLine($"-ReleaseDate: {al.ReleaseDate.ToString("MM/dd/yyyy")}");
                sb.AppendLine($"-ProducerName: {al.ProducerName}");
                sb.AppendLine("-Songs:");
                int n = 1;
                foreach (var song in al.Songs.OrderByDescending(x=>x.Name).ThenBy(x=>x.WriterName))
                {
                    sb.AppendLine($"---#{n++}");
                    sb.AppendLine($"---SongName: {song.Name}");
                    sb.AppendLine($"---Price: {song.Price:f2}");
                    sb.AppendLine($"---Writer: {song.WriterName}");
                }
                sb.AppendLine($"-AlbumPrice: {al.AlbumPrice:f2}");
            }
            

            return sb.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder sb = new();
         
            var songs = context.Songs
                .AsEnumerable()
                .Where(x => x.Duration.TotalSeconds > duration)
                .OrderBy(x=>x.Name)
                .ThenBy(x=>x.Writer.Name)
                .Select(x => new
                {
                    x.Name,
                    Performers = x.SongPerformers
                    .Select(x=>new { FullName = $"{x.Performer.FirstName} {x.Performer.LastName}"}),
                    WriterName = x.Writer.Name,
                    AlbumProducerName = x.Album.Producer.Name,
                    x.Duration 
                }).ToArray();
            int n = 1;
            foreach (var song in songs) 
            {
                sb.AppendLine($"-Song #{n++}");
                sb.AppendLine($"---SongName: {song.Name}");
                sb.AppendLine($"---Writer: {song.WriterName}");
                if (song.Performers.Count()>0)
                {
                    foreach (var per in song.Performers.OrderBy(x=>x.FullName))
                    {
                        sb.AppendLine($"---Performer: {per.FullName}");
                    }
                }
                sb.AppendLine($"---AlbumProducer: {song.AlbumProducerName}");
                sb.AppendLine($"---Duration: {song.Duration}");
            }

            return sb.ToString().Trim();
        }

    }
}
