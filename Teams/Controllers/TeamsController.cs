using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Common.Models;
using Common.Interfaces;
using DataAccessLayer;
using WebApp.ViewModels;

namespace WebApp.Controllers
{

    public class TeamsController : Controller
    {

        private ITeamsRepository _repositiry;

        public TeamsController()
        {
            _repositiry = new InMemoryRepository();
        }


        public IActionResult TeamsList()
        {
            return View("~/Views/Teams/TeamsList.cshtml", _repositiry.GetTeams());
        }

        public IActionResult Details(int id)
        {
            Team currTeam = _repositiry.GetTeamById(id);

            if (currTeam != null)
            {
                var allPlayers = _repositiry.GetPersons();
                var detailsViewModel = new TeamDetailsViewModel()
                {
                    Id = currTeam.Id,
                    Name = currTeam.Name,
                    teamPlayers = allPlayers.Where(p => p.Team == currTeam),
                    unassignedPlayers = allPlayers.Where(p => p.Team == null)

                };

                return View(detailsViewModel);
            }
            else
            {
                return RedirectToAction("TeamsList");
            }
        }

        [HttpPost]
        public IActionResult AddPlayerToTeam(int teamId, int selectedPlayerId)
        {
            Person currPlayer = _repositiry.GetPersonById(selectedPlayerId);
            Team currTeam = _repositiry.GetTeamById(teamId);

            if (currPlayer != null && currTeam != null)
            {
                currPlayer.Team = currTeam;
                return RedirectToAction("Details", new { id = teamId });
            }
            else
            {
                return RedirectToAction("TeamsList");
            }
        }

    }
}