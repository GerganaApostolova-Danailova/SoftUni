using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string userName = Console.ReadLine();
            int level = int.Parse(Console.ReadLine());

            MuseElf museElf = new MuseElf(userName, level);

            Console.WriteLine(museElf);
        }
    }
}