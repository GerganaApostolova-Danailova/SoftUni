using System;
using System.Collections.Generic;
using System.Text;

namespace _05._Teamwork_Projects
{
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
}
