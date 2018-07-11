using System;
using System.Collections.Generic;
using Common.Models;

namespace Common.Interfaces
{
    public interface ITeamsRepository
    {
        IEnumerable<Team> GetTeams();
        IEnumerable<Person> GetPersons();

        Team GetTeamById(int teamId);
        void InsertTeam(Team team);
        void DeleteTeam(int teamID);
        void UpdateTeam(Team team);

        Person GetPersonById(int personId);
        void InsertPerson(Person person);
        void DeletePerson(int personID);
        void UpdatePerson(Person person);
    }
}
