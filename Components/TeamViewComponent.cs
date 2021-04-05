using BowlingSite.Models;
using BowlingSite.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingSite.Components
{
    public class TeamViewComponent : ViewComponent
    {
        private BowlingLeagueContext context;
        public TeamViewComponent(BowlingLeagueContext ctx)
        {
            context = ctx;
        }
        public IViewComponentResult Invoke()
        {

            return View(
                new TeamViewModel
                {
                    Teams = (context.Teams
                .Distinct()
                .OrderBy(x => x)),
                    currentTeam = "Marlins"
                });
        }
    }
}
