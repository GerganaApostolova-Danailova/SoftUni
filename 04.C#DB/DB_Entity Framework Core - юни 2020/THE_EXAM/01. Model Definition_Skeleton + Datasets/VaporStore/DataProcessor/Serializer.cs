namespace VaporStore.DataProcessor
{
	using System;
    using System.Linq;
    using Data;

	public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
			//var games = context
			//	.Genres
			//	.ToArray()
			//	.Where(g=>g.Games.Any(p =>p.Purchases.Any()))
			//	.Select(g=> new
			//             {
			//		Id = g.Id,
			//		Genre = g.Name,
			//		Games = g.Games.Select(x=> new
			//		{
			//			Id = x.Id,
			//			Title = x.Name,
			//			Developer = x.Developer.Name,
			//			Tags = x.GameTags.SE
			//		})
			//		//TotalPlayers = g.Games.Count()
			//	}),
			//	TotalPlayers = g.Ga

			return null;
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
			return null;
		}
	}
}