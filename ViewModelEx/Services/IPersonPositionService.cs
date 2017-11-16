using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ViewModelEx.Models;

namespace ViewModelEx.Services
{
    interface IPersonPositionService
    {

        List<PersonPositionViewModel> GetAll();
        PersonPositionViewModel FindById(int id);
    }
}
