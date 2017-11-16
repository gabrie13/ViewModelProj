using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ViewModelEx.Models
{
    public class EmployeeViewModel
    {
        [Key]
        public int EmployeeId { get; set; }
        public IEnumerable<Person> People { get; set; }
        public IEnumerable<Location> Locations { get; set; }
        public IEnumerable<Position> Positions { get; set; }
    }

}