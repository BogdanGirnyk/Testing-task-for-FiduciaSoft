using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Models;
using Common.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class TeamDetailsViewModel
    {
        public int Id;
        public string Name;

        public IEnumerable<Person> teamPlayers;
        public IEnumerable<Person> unassignedPlayers;

        public int selectedPlayerId { get; set; }

        public IEnumerable<SelectListItem> unassignedPlayersItems
        {
            get { return new SelectList(unassignedPlayers, "Id", "Name"); }
        }

    }
}
