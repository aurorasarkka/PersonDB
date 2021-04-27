using PersonDB.Models;
using PersonDB.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDB.Views
{
    class PersonView : IPersonView
    {
        private readonly IPersonService _personService;

        public PersonView()
        {
            _personService = new PersonService();
        }
        public void CreatePerson()
        {
            person newPerson = new person();

            Console.WriteLine(" Anna etunimi: ");
            newPerson.FirstName = Console.ReadLine();
            Console.WriteLine(" Anna sukunimi: ");
            newPerson.Lastname = Console.ReadLine();
            Console.WriteLine(" Anna kaupunki: ");
            newPerson.City = Console.ReadLine();
            Console.WriteLine(" Anna sukupuoli: ");
            newPerson.Sex = Console.ReadLine();

            newPerson =  _personService.Create(newPerson);
            if (newPerson != null)
            {
                Console.WriteLine("Henkilön lisääminen onnistui");
            }
            else
            {
                Console.WriteLine("Henkilön lisääminen epäonnistui");
            }

        }

        public void DeletePerson()
        {
            Console.Write("Syötä henkilön Id:");
            long id = Convert.ToInt64(Console.ReadLine());
            var person = _personService.Read(id);
            PrintPerson(person);

            _personService.Delete(id, person);
        }

        public void PrintAllPeople()
        { 
            var people = _personService.Read();
            PrintPeople(people);
        }

        public void PrintByCity()
        {
            Console.Write("Syötä kaupungin nimi:");
            string city = Console.ReadLine();
            var people = _personService.Read(city);
            PrintPeople(people);
        }

        public void PrintSinglePerson()
        {
            Console.Write("Syötä henkilön Id:");
            long id = Convert.ToInt64(Console.ReadLine());
            var person = _personService.Read(id);
            PrintPerson(person);
        }

        public void UpdatePerson()
        {
            Console.Write("Syötä henkilön Id:");
            long id = Convert.ToInt64(Console.ReadLine());
            var person = _personService.Read(id);
            PrintPerson(person);

            //Kysy arvot
            Console.WriteLine(" Anna uusi etunimi: ");
            person.FirstName = Console.ReadLine();
            Console.WriteLine(" Anna uusi sukunimi: ");
            person.Lastname = Console.ReadLine();
            Console.WriteLine(" Anna uusi kaupunki: ");
            person.City = Console.ReadLine();

            _personService.Delete(id, person);
        }


        private void PrintPeople(List<person> people)
        {
            Console.WriteLine("Id\tEtunimi\tSukunimi\tSukupuoli\tKaupunki");
            foreach (var p in people)
            {
                PrintPerson(p);
            }
        }
        private void PrintPerson(person p)
        {
            Console.WriteLine($"{p.Id}\t{p.FirstName}\t{p.Lastname}\t{p.Sex}\t{p.City}");
        }
    }
}
