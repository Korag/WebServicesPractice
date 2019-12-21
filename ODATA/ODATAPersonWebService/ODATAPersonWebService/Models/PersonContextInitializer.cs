using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ODATAPersonWebService.Models
{
    public class PersonContextInitializer : DropCreateDatabaseAlways<ODATAPersonWebServiceContext>
    {
        protected override void Seed(ODATAPersonWebServiceContext context)
        {
            var ludzie = new List<Person>
       {

            new Person { Id = "1", FirstName = "Tomato Soup", LastName = "aaa"},
            new Person { Id = "2", FirstName = "Yo-yo", LastName = "bbb"},
            new Person { Id = "3", FirstName = "Hammer", LastName = "ccc" }
       };

            foreach (var lud in ludzie)
            {
                context.People.Add(lud);
            }

            base.Seed(context);
        }
    }
}