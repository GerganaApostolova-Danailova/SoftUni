namespace MusicHub.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Microsoft.Extensions.Configuration;
    using MusicHub.Data.Models;
    using MusicHub.DataProcessor.ImportDtos;
    using Newtonsoft.Json;
    using MusicHub.XMLHelper;
    using MusicHub.Data.Models.Enums;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            var jsonOutput = JsonConvert
                .DeserializeObject<ImportWrotersDto[]>(jsonString);

            var correctWriters = new List<Writer>();

            var sb = new StringBuilder();

            foreach (ImportWrotersDto wrotersDto in jsonOutput)
            {
                if (!IsValid(wrotersDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var newWriter = new Writer
                {
                    Name = wrotersDto.Name,
                    Pseudonym = wrotersDto.Pseudonym
                };

                correctWriters.Add(newWriter);

                sb.AppendLine(String.Format(SuccessfullyImportedWriter, wrotersDto.Name));

            }

            context.Writers.AddRange(correctWriters);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var jsonResult = JsonConvert
                .DeserializeObject<ImportProducerAndAlbumsDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            foreach (ImportProducerAndAlbumsDto prDto in jsonResult)
            {
                if (!IsValid(prDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                var newProduser = new Producer
                {
                    Name = prDto.Name,
                    Pseudonym = prDto.Pseudonym,
                    PhoneNumber = prDto.PhoneNumber
                };

                var isValidAlbum = true;

                foreach (ImportAlbumsDto albumDtom in prDto.Albums)
                {

                    if (!IsValid(albumDtom))
                    {
                        isValidAlbum = false;
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var releaseDate = DateTime.ParseExact(albumDtom.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    var newAlbum = new Album
                    {
                        Name = albumDtom.Name,
                        ReleaseDate = releaseDate,
                    };

                    newProduser.Albums.Add(newAlbum);
                }

                if (!isValidAlbum)
                {
                    continue;
                }

                context.Producers.Add(newProduser);

                if (prDto.PhoneNumber == null)
                {
                    sb
                        .AppendLine(String.Format(SuccessfullyImportedProducerWithNoPhone, prDto.Name, prDto.Albums.Count()));
                }
                else
                {
                    sb
                        .AppendLine(String.Format(SuccessfullyImportedProducerWithPhone, prDto.Name, prDto.PhoneNumber, prDto.Albums.Count()));
                }
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            var xmlResult = XmlConverter
                .Deserializer<ImportSongsDto>(xmlString, "Songs");

            StringBuilder sb = new StringBuilder();

            foreach (ImportSongsDto songsDto in xmlResult)
            {
                if (!IsValid(songsDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Genre genre;
                var validGenre = Enum.TryParse<Genre>(songsDto.Genre.ToString(), out genre);

                if (!validGenre)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (songsDto.WriterId == 0 || !context.Writers.Any(w => w.Id == songsDto.WriterId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!context.Albums.Any(a => a.Id == songsDto.AlbumId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var newSong = new Song
                {
                    Name = songsDto.Name,
                    Duration = TimeSpan.ParseExact(songsDto.Duration, "c", CultureInfo.InvariantCulture),
                    CreatedOn = DateTime.ParseExact(songsDto.CreatedOn, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Genre = genre,
                    AlbumId = songsDto.AlbumId,
                    WriterId = songsDto.WriterId,
                    Price = songsDto.Price
                };

                context.Songs.Add(newSong);

                sb
                    .AppendLine(String.Format(SuccessfullyImportedSong,
                    songsDto.Name, songsDto.Genre, songsDto.Duration));
            }
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            var xmlResult = XmlConverter
                .Deserializer<ImportSongPerformerDto>(xmlString, "Performers");

            StringBuilder sb = new StringBuilder();

            foreach (ImportSongPerformerDto spDto in xmlResult)
            {
                if (!IsValid(spDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var performer = new Performer
                {
                    FirstName = spDto.FirstName,
                    LastName = spDto.LastName,
                    Age = spDto.Age,
                    NetWorth = spDto.NetWorth
                };

                var isValisSongId = true;

                foreach (ImportPerformertCollectionDto pDto in spDto.PerformersSongs)
                {
                    if (!context.Songs.Any(s => s.Id == pDto.Id) || !IsValid(pDto))
                    {
                        isValisSongId = false;
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var songPerformer = new SongPerformer
                    {
                        PerformerId = performer.Id,
                        SongId = pDto.Id
                    };

                    performer.PerformerSongs.Add(songPerformer);
                }

                if (!isValisSongId)
                {
                    continue;
                }

                context.Performers.Add(performer);

                sb.AppendLine(String.Format(SuccessfullyImportedPerformer, spDto.FirstName, spDto.PerformersSongs.Count()));
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}