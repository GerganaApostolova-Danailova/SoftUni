using System;
using Microsoft.Data.SqlClient;


namespace _2._Villain_Names
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SqlConnection sqlConnection =
                new SqlConnection(@"Server=TCECO\WINCC;Database=MinionsDB;Integrated Security=true");

            using (sqlConnection)
            {
                sqlConnection.Open();

                var villainsNamesCommand = "SELECT  v.Name, COUNT(mv.MinionId) AS [Count] " +
                           "FROM MinionsVillains AS mv JOIN Villains AS v ON mv.VillainId = v.Id  " +
                           "GROUP BY v.Id, v.Name  HAVING COUNT(mv.MinionId) > 3  ORDER BY[Count] DESC";

                var getVillainsMinionsCount = new SqlCommand(villainsNamesCommand, sqlConnection);

                using (SqlDataReader reader = getVillainsMinionsCount.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var villainsName = reader["Name"].ToString();
                        var minionsCount = (int)reader["Count"];
                        Console.WriteLine($"{villainsName} - {minionsCount}");
                    }
                }

            }
        }
    }
}
