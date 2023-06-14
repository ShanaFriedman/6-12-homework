using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace June12Homework.Data
{
    public class PersonRepository
    {
        private readonly string _connectionString;
        public PersonRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void DeleteAll()
        {
            var context = new PeopleDbContext(_connectionString);
            var people = context.People.ToList();
            context.RemoveRange(people);
            context.SaveChanges();
        }
        public void AddPeople(List<Person> people)
        {
            var context = new PeopleDbContext(_connectionString);
            context.AddRange(people);
            context.SaveChanges();
        }
        public List<Person> GetPeople()
        {
            var context = new PeopleDbContext(_connectionString);
            return context.People.ToList();
        }
    }
}
