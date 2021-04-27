using PersonDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDB.Services
{
    public interface IPersonService
    {
        person Create(person person);
        List<person> Read();
        person Read(long id);
        List<person> Read(string City);
        person Delete(long id, person person);
        void Delete(long id);
    }
}
