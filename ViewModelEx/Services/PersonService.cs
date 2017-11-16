using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ViewModelEx.Models;

namespace ViewModelEx.Services
{
    public class PersonService : IPersonService
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<PersonViewModel> GetAll()
        {
            var personList = db.People.ToList();
            return personList.Select(per => PerDto(per)).ToList();
        }

        private PersonViewModel PerDto(Person per)
        {
            return new PersonViewModel
            {
                PersonId = per.PersonId,
                FirstName = per.FirstName,
                LastName = per.LastName,
                Phone = per.Phone
            };
        }

        public PersonViewModel FindById(int id)
        {
            var person = db.People.Find(id);
            return person != null ? PerDto(person) : null;
        }

        public PersonViewModel Create(PersonViewModel person)
        {
            var per = FromPer(person);
            db.People.Add(per);
            db.SaveChanges();

            per.PersonId = person.PersonId;
            return PerDto(per);
        }

        private static Person FromPer(PersonViewModel person)
        {
            var per = new Person
            {
                PersonId = person.PersonId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Phone = person.Phone
            };
            return per;
        }

        public PersonViewModel Save(PersonViewModel person)
        {
            var per = FromPer(person);
            db.Entry(per).State = EntityState.Modified;
            db.SaveChanges();

            return PerDto(per);
        }

        public void Delete(int id)
        {
            Person person = db.People.Find(id);
            db.People.Remove(person);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}