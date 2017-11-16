using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ViewModelEx.Models;

namespace ViewModelEx.Services
{
    interface ILocationService
    {
        List<LocationViewModel> GetAll();
        LocationViewModel FindById(int id);
        LocationViewModel Create(LocationViewModel location);
        LocationViewModel Save(LocationViewModel location);
        void Delete(int id);
        void Dispose();
    }
}
