using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ViewModelEx.Models
{
    public class ApplicationDbContextSetInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            //LOCATION TABLE AUTO POPULATED
            context.Locations.Add(new Location { LocationId = 1, LocationName = "SLC",   City = "SLC",         State = "UT"});
            context.Locations.Add(new Location { LocationId = 2, LocationName = "Mesa",  City = "Mesa",        State = "AZ" });
            context.Locations.Add(new Location { LocationId = 3, LocationName = "Falls", City = "Idaho Falls", State = "ID" });
            context.Locations.Add(new Location { LocationId = 4, LocationName = "Vegas", City = "Las Vegas",   State = "NV" });

            //Position TABLE AUTO POPULATED
            context.Positions.Add(new Position { PositionId = 1, Title = "RM" });
            context.Positions.Add(new Position { PositionId = 2, Title = "DM" });
            context.Positions.Add(new Position { PositionId = 3, Title = "GM" });
            context.Positions.Add(new Position { PositionId = 4, Title = "AM" });
            context.Positions.Add(new Position { PositionId = 5, Title = "KM" });
            context.Positions.Add(new Position { PositionId = 6, Title = "SM" });

            //PERSON TABLE AUTO POPULATED
            context.People.Add(new Person { PersonId = 1, FirstName = "Brandon", LastName = "Wallick", Phone = "801-971-2554" });
            context.People.Add(new Person { PersonId = 2, FirstName = "Mario",   LastName = "Lopez",   Phone = "801-555-4888" });
            context.People.Add(new Person { PersonId = 3, FirstName = "Bethany", LastName = "Bown",    Phone = "801-553-7812" });
            context.People.Add(new Person { PersonId = 4, FirstName = "Caitlyn", LastName = "Hughes",  Phone = "801-145-6372" });
            context.People.Add(new Person { PersonId = 5, FirstName = "Jesus",   LastName = "Agular",  Phone = "801-375-1671" });

            base.Seed(context);
        }
    }
}