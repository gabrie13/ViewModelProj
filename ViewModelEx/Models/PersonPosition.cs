using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ViewModelEx.Models
{
    public class PersonPosition
    {
        [Key]
        public int PersonPositionId { get; set; }

        public int PositionId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public virtual Person Person { get; set; }
        public virtual Position Position { get; set; }
    }
}