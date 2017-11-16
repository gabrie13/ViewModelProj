using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ViewModelEx.Models;

namespace ViewModelEx.Services
{
    interface IPersonService
    {
        List<PersonViewModel> GetAll();
        PersonViewModel FindById(int id);
        PersonViewModel Create(PersonViewModel person);
        PersonViewModel Save(PersonViewModel person);
        void Delete(int id);
        void Dispose();
    }
}
