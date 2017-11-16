using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ViewModelEx.Models
{
    public class LocationViewModel
    {
        [Key]
        public int LocationId { get; set; }

        [Display(Name = "Location")]
        public string LocationName { get; set; }

        public string City { get; set; }

        public string State { get; set; }
    }
}