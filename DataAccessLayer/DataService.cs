using Common.Models;
using Common.Interfaces;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class InMemoryRepository : ITeamsRepository
    {
        private static List<Team> teams { get; set; }
        private static List<Person> people { get; set; }

        static InMemoryRepository()
        {
            var eagles = new Team { Id = 1, Name = "Eagles" };
            var bears = new Team { Id = 2, Name = "Bears" };

            teams = new List<Team>
            {
                eagles,
                bears
            };

            people = new List<Person>
            {
                new Person { Id = 1, Name = "John" },
                new Person { Id = 2, Name = "Joe" },
                new Person { Id = 3, Name = "Ed", Team = eagles },
                new Person { Id = 4, Name = "Merphy", Team = bears },
                new Person { Id = 5, Name = "Met", Team = bears },
            };
        }

        public IEnumerable<Team> GetTeams()
        {
            return teams;
        }

        public IEnumerable<Person> GetPersons()
        {
            return people;
        }

        public Team GetTeamById(int teamId)
        {
            return teams.Find(t => t.Id == teamId);
        }

        public void InsertTeam(Team team)
        {
            throw new NotImplementedException();
        }

        public void DeleteTeam(int teamID)
        {
            throw new NotImplementedException();
        }

        public void UpdateTeam(Team team)
        {
            throw new NotImplementedException();
        }

        public Person GetPersonById(int personId)
        {
            return people.Find(t => t.Id == personId);
        }

        public void InsertPerson(Person person)
        {
            throw new NotImplementedException();
        }

        public void DeletePerson(int personID)
        {
            throw new NotImplementedException();
        }

        public void UpdatePerson(Person person)
        {
            Person currPerson = GetPersonById(person.Id);
            if (currPerson!=null)
            {
                currPerson = person;
            }
            else
            {
                throw new ArgumentException(String.Format("No person found with id {0}", person.Id));
            }
        }
    }
}
