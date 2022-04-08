namespace MusicHub.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using MusicHub.DataProcessor.ExportDtos;
    using MusicHub.XMLHelper;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context
                .Albums
                .ToArray()
                .Where(a => a.ProducerId == producerId)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs.Select(s => new
                    {
                        SongName = s.Name,
                        Price = s.Price.ToString("F2"),
                        Writer = s.Writer.Name
                    })
                    .OrderByDescending(s => s.SongName)
                    .ThenBy(s => s.Writer),
                    //.ToArray(),
                    AlbumPrice = a.Songs.Sum(s => s.Price).ToString("f2")
                })
                .OrderByDescending(a => a.AlbumPrice)
                .ToArray();

            var json = JsonConvert.SerializeObject(albums, Formatting.Indented);

            return json;
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {

            var songs = context
                 .Songs
                 .ToArray()
                 .Where(s => s.Duration.TotalSeconds > duration)
                 .Select(s => new ExportSongsDto
                 {
                     SongName = s.Name,
                     Writer = s.Writer.Name,
                     Performer = s.SongPerformers.Select(p => p.Performer.FirstName + " " + p.Performer.LastName).FirstOrDefault(),
                     AlbumProducer = s.Album.Producer.Name,
                     Duration = s.Duration.ToString("c", CultureInfo.InvariantCulture)
                 })
                 .OrderBy(s => s.SongName)
                 .ThenBy(s => s.Writer)
                 .ThenBy(s => s.Performer)
                 .ToArray();

            var xml = XmlConverter.Serialize<ExportSongsDto>(songs, "Songs");

            return xml;
        }
    }
}