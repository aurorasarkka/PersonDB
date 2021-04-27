using PersonDB.Models;
using PersonDB.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDB.Services
{
    class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService()
        {
            _personRepository = new PersonRepository();
        }

        public person Create(person person)
        {
            var createdPerson = _personRepository.CreatePerson(person);
            return createdPerson;
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();





        }

        public person Delete(long id, person person)
        {
            throw new NotImplementedException();
        }

        public List<person> Read()
        {
            var people = _personRepository.Read();
            return people;
        }

        public person Read(long id)
        {
            var person = _personRepository.Read(id);
            return person;
           
        }

        public List<person> Read(string City)
        {
            var people = _personRepository.Read(City);
            return people;
        }

        public person Update(long id, person person)
        {
            var dbPerson = _personRepository.Read(id);
            if (dbPerson != null)
            {
                person.Id = id;
               var updatePerson = _personRepository.UpdatePerson(person);
                return updatePerson;
            }
            else
            {
                Console.WriteLine("henkilöä ei ole olemassa - päivitys ei onnistu");
                return null;
            }
        }
    }
}
