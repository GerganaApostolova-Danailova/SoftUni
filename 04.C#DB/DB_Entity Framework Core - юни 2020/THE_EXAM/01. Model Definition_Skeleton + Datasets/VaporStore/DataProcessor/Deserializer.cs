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
    using Castle.Core.Internal;
    using Data;
    using Microsoft.EntityFrameworkCore.Internal;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;
    using VaporStore.XMLHelper;

    public static class Deserializer
    {
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var gamesDTOs = JsonConvert.DeserializeObject<ImportGDGTDto[]>(jsonString);

            var games = new List<Game>();
            var developers = new List<Developer>();
            var genres = new List<Genre>();
            var tags = new List<Tag>();
            var sb = new StringBuilder();

            foreach (var dto in gamesDTOs)
            {
                Developer developer;
                Genre genre;

                int tagCount = 0;

                if (!IsValid(dto) || dto.Tags.Length == 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                developer = developers.FirstOrDefault(d => d.Name == dto.Developer);
                genre = genres.FirstOrDefault(g => g.Name == dto.Genre);

                var newGame = new Game()
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    ReleaseDate = DateTime.ParseExact(dto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Developer = developer == null ? new Developer() { Name = dto.Developer } : developer,
                    Genre = genre == null ? new Genre() { Name = dto.Genre } : genre
                };

                foreach (var tag in dto.Tags)
                {
                    if (tags.FirstOrDefault(t => t.Name == tag) == null)
                    {
                        var tagtoAdd = new Tag() { Name = tag };
                        newGame.GameTags.Add(new GameTag { Game = newGame, Tag = tagtoAdd });
                        tags.Add(tagtoAdd);
                    }
                    else
                    {
                        var foundTag = tags.FirstOrDefault(t => t.Name == tag);
                        newGame.GameTags.Add(new GameTag { Game = newGame, Tag = foundTag });
                    }
                    tagCount++;
                }

                games.Add(newGame);
                if (developer == null)
                {
                    developers.Add(newGame.Developer);
                }
                if (genre == null)
                {
                    genres.Add(newGame.Genre);
                }

                sb.AppendLine(string.Format($"Added {newGame.Name} ({newGame.Genre.Name}) with {tagCount} tags"));
            }

            context.Tags.AddRange(tags);
            context.Games.AddRange(games);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var userDto = JsonConvert
                .DeserializeObject<ImportUserCardsDto[]>(jsonString);

            var sb = new StringBuilder();

            var users = new List<User>();

            foreach (var user in userDto)
            {
                if (!IsValid(userDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if (!user.Cards.Any())
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if (user.FullName.IsNullOrEmpty())
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }


                if (user.FullName.Contains("Invalid") || user.FullName.Contains("invalid"))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var newUser = new User
                {
                    FullName = user.FullName,
                    Username = user.Username,
                    Email = user.Email,
                    Age = user.Age
                };

                foreach (var card in user.Cards)
                {
                    if (!IsValid(card))
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }

                    CardType type;
                    var validType = Enum.TryParse<CardType>(card.Type.ToString(), out type);

                    if (!validType)
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }

                    newUser.Cards.Add(new Card()
                    {
                        Number = card.Number,
                        Cvc = card.Cvc,
                        Type = type
                    });

                }
                users.Add(newUser);

                string name = user.FullName;
                
                string[] name2 = name.Split(" ");

                char[] nameArray = name.ToLower().ToCharArray();
                string other = nameArray[0] + name2[1];
                other.ToLower();

                sb.AppendLine($"Imported {other.ToLower()} with {user.Cards.Count()} cards");
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportPurchasesDto[]), new XmlRootAttribute("Purchases"));

            StringBuilder sb = new StringBuilder();

            using (StringReader sr = new StringReader(xmlString))
            {
                var purchasesDtos = (ImportPurchasesDto[])serializer.Deserialize(sr);

                List<Purchase> purchases = new List<Purchase>();
                

                foreach (var purchaseDto in purchasesDtos)
                {
                    if (!IsValid(purchaseDto))
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }

                    var card = context.Cards.FirstOrDefault(x => x.Number == purchaseDto.Card);

                    var game = context.Games.FirstOrDefault(x => x.Name == purchaseDto.Titel);

                    var date = DateTime.ParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None);
                    
                    Purchase purchase = new Purchase
                    {
                        Type = Enum.Parse<PurchaseType>(purchaseDto.Type),
                        ProductKey = purchaseDto.Key,
                        Card = card,
                        Date = date,
                        Game = game
                    };

                    var name = context.Users.FirstOrDefault(x => x.Id == purchase.Card.UserId);

                    purchases.Add(purchase);

                    sb.AppendLine($"Imported {purchase.Game.Name} for {name.Username}");
                }

                context.Purchases.AddRange(purchases);
                context.SaveChanges();
            }
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