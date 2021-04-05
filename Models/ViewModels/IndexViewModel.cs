using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingSite.Models.ViewModels
{
    public class IndexViewModel
    {
        public List<Bowler> Bowlers { get; set; }
        public PageNumberInfo PageNumberInfo { get; set; }
        public string SelectedTeam { get; set; } = "Bowlers";
    }
}
