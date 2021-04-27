using PersonDB.Data;
using PersonDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonDB.Repositories
{
    class PersonRepository : IPersonRepository
    {
        private readonly PersonTestDBContext _context;

        public PersonRepository()
        {
            _context = new PersonTestDBContext();
        }
        public person CreatePerson(person person)
        {
            var CreatedPerson = _context.People.Add(person).Entity;
            _context.SaveChanges();
            return CreatedPerson;
           
        }

        public person DeletePerson(person person)
        {
            var DeletedPerson = _context.People.Remove(person).Entity;
            _context.SaveChanges();
            return null;
        }

        public List<person> Read()
        {
            var people = _context.People.ToList();
            return people;
        }

        public person Read(long id)
        {
            var person = _context.People.Find(id);
            return person;
        }

        public List<person> Read(string city)
        {
            var people = _context.People.Where(p => p.City == city).ToList();
            return people;
        }

        public person UpdatePerson(person person)
        {
            try
            {


                var UpdatedPerson = _context.People.Update(person).Entity;
                _context.SaveChanges();
                return UpdatedPerson;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Päivittäminen ei onnistunut:" + ex);
                return null;
            }
        }

        void IPersonRepository.DeletePerson(person person)
        {
            throw new NotImplementedException();
        }
    }
}
