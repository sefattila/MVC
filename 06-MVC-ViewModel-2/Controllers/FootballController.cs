using _06_MVC_ViewModel_2.Models;
using _06_MVC_ViewModel_2.Models.VMs;
using Microsoft.AspNetCore.Mvc;

namespace _06_MVC_ViewModel_2.Controllers
{
    public class FootballController : Controller
    {
        public List<FootballPlayer> footballPlayers = new List<FootballPlayer>()
        {
            new FootballPlayer
            {
                Id= 1,
                Name="Aboubakar",
                Age=31,
                PositionId= 9,
                TeamId= 1903,
            },
            new FootballPlayer
            {
                Id= 2,
                Name="Olcay Şahan",
                Age=31,
                PositionId= 10,
                TeamId= 1903,
            }
        };

        public List<Team> teams = new List<Team>()
        {
            new Team{Id=1903,Name="BEŞİKTAŞ JK"}
        };

        public List<Position> positions = new List<Position>()
        {
            new Position{Id=9,Name="Santrafor"},
            new Position{Id=10,Name="OOS"}
        };

        public IActionResult Index()
        {
            //var viewModel = footballPlayers
            //       .Select(fp => new FootballPlayerVMs
            //       {
            //           Id = fp.Id,
            //           Name = fp.Name,
            //           Age = fp.Age,
            //           PositionName = positions.FirstOrDefault(p => p.Id == fp.PositionId)?.Name,
            //           TeamName = teams.FirstOrDefault(t => t.Id == fp.TeamId)?.Name
            //       })
            //       .ToList();
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateVMs createVMs= new CreateVMs();
            createVMs.FootballPlayers = new FootballPlayer();
            createVMs.Positions = positions;
            createVMs.Teams = teams;

            return View(createVMs);
        }

        [HttpPost]
        public IActionResult Create(FootballPlayer footballPlayer)
        {
            var position=positions.FirstOrDefault(x=>x.Id==footballPlayer.PositionId);
            var team=teams.FirstOrDefault(x=>x.Id== footballPlayer.TeamId);
            footballPlayer.Position = position;
            footballPlayer.Team = team;

            return View("Index",footballPlayer);
        }
    }
}
