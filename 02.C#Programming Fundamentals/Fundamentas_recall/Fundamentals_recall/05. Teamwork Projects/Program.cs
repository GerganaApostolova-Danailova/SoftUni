using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Teamwork_Projects
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();


            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split("-");

                string creator = command[0];
                string teamName = command[1];

                bool isExistingTeamName = IsExistingTeamName(teamName, teams);

                bool isExistingCreator = IsExistingCreator(creator, teams);

                if (isExistingTeamName)
                {
                    Console.WriteLine($"Team {teamName} was already created!");

                }
                if (isExistingCreator)
                {
                    Console.WriteLine($"{creator} cannot create another team!");

                }
                if (!isExistingTeamName && !isExistingCreator)
                {
                    Team team = new Team(teamName, creator);
                    teams.Add(team);
                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                }
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end of assignment")
            {
                string[] memberAndTeam = input.Split("->");

                string member = memberAndTeam[0];
                string teamName = memberAndTeam[1];

                string currentTeamName = string.Empty;
                bool isExistingMember = true;

                foreach (var team in teams)
                {
                    if (team.Members.Contains(member))
                    {
                        isExistingMember = true;
                        currentTeamName = team.TeamName;
                        break;
                    }
                    isExistingMember = false;
                }

                var existTeamName = teams.FirstOrDefault(x => x.TeamName == teamName);

                bool existCreatorWhithMemberName = true;

                foreach (var team in teams)
                {
                    if (team.Creator == member)
                    {
                        currentTeamName = team.TeamName;
                        existCreatorWhithMemberName = true;
                        break;
                    }
                    existCreatorWhithMemberName = false;
                }

                if ((existTeamName != null) && isExistingMember == false && existCreatorWhithMemberName == false)
                {
                    var existingTeam = teams.First(x => x.TeamName == teamName);

                    existingTeam.Members.Add(member);
                }
                if (existTeamName == null)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                if (isExistingMember || existCreatorWhithMemberName)
                {
                    Console.WriteLine($"Member {member} cannot join team {currentTeamName}!");
                }
            }

            List<string> disbanedTeams = new List<string>();

            for (int i = 0; i < teams.Count; i++)
            {
                if (!teams[i].Members.Any())
                {
                    disbanedTeams.Add(teams[i].TeamName);
                    teams.Remove(teams[i]);
                    i++;
                }
            }

            var sortedTeamsByName = teams.OrderByDescending(x => x.TeamName).ToList();

            foreach (var team in sortedTeamsByName)
            {
                Console.WriteLine($"{team.TeamName}");
                Console.WriteLine($"- {team.Creator}");

                foreach (var member in team.Members)
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            var sortedDanedAsc = disbanedTeams.OrderBy(x => x).ToList();

            Console.WriteLine($"Teams to disband:");
            foreach (var disbaned in sortedDanedAsc)
            {
                Console.WriteLine(disbaned);
            }

        }

        public class Team
        {
            public Team(string teamName, string creator)
            {
                this.TeamName = teamName;
                this.Creator = creator;
                this.Members = new List<string>();
            }

            public string TeamName { get; set; }

            public string Creator { get; set; }

            public List<string> Members { get; set; }
        }

        public static bool IsExistingTeamName(string teamName, List<Team> teams)
        {
            var sortedTeams = teams.FirstOrDefault(x => x.TeamName == teamName);

            if (sortedTeams == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsExistingCreator(string creator, List<Team> teams)
        {
            var sortedTeams = teams.FirstOrDefault(x => x.Creator == creator);

            if (sortedTeams == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
