using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingSite.Models.ViewModels
{
    public class TeamViewModel
    {
        public IEnumerable<Team> Teams { get; set; }
        public string currentTeam { get; set; }
    }
}
