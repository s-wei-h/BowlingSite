using BowlingSite.Models;
using BowlingSite.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BowlingLeagueContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext ctx)
        {
            _logger = logger;
            context = ctx;
        }

        public IActionResult Index(int? teamId, string teamName, int pagenum = 0)
        {
            int pageSize = 5;

            //create indexviewmodel to select bowlers and pagenumberinfo to pass to url
            return View(new IndexViewModel
            {
                Bowlers = (context.Bowlers
                //.FromSqlInterpolated($"SELECT * FROM Bowlers WHERE TeamId = {teamId} OR {teamId} IS NULL")
                .Where(b => b.TeamId == teamId || teamId == null)
                .OrderBy(b => b.BowlerLastName)
                .Skip((pagenum - 1) * pageSize)
                .Take(pageSize)
                .ToList()),

                PageNumberInfo = new PageNumberInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pagenum,
                    //check if null, if not then get count of bowlers in team
                    TotalNumItems = (teamId == null ? context.Bowlers.Count() : 
                        context.Bowlers.Where(b => b.TeamId == teamId).Count())

                },
                SelectedTeam = teamName
            });       
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
