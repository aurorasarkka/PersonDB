using PersonDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDB.Repositories
{
    public interface IPersonRepository
    {
        //CRUD
        //Create, Read, Update, Delete

        person CreatePerson(person person);

        List<person> Read();

        person Read(long id);

        List<person> Read(string city);

        person UpdatePerson(person person);

        void DeletePerson(person person);
    }
}
