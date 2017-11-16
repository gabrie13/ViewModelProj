using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ViewModelEx.Models;

namespace ViewModelEx.Services
{
    public class PersonPositionService : IPersonPositionService
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<PersonPositionViewModel> GetAll()
        {
            var personPositionList = db.PersonPositions.ToList();
            return personPositionList.Select(pp => PpDto(pp)).ToList();
        }

        private static PersonPositionViewModel PpDto(PersonPosition pp)
        {
            return new PersonPositionViewModel
            {
                PersonPositionId = pp.PositionId,
                FirstName = pp.FirstName,
                LastName = pp.LastName,
                Phone = pp.Phone,
                PositionId = pp.PositionId,
                Person = pp.Person,
                Position = pp.Position

            };
        }

        public PersonPositionViewModel FindById(int id)
        {
            var personPosition = db.PersonPositions.Find(id);
            return personPosition != null ? PpDto(personPosition) : null;
        }
    }
}