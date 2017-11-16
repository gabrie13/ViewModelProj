using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ViewModelEx.Models
{
    public class PositionViewModel
    {
        [Key]
        public int PositionId { get; set; }

        public string Title { get; set; }
    }
}