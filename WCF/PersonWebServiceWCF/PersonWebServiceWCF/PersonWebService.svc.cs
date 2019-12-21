using PersonWebServiceWCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PersonWebServiceWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PersonWebService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PersonWebService.svc or PersonWebService.svc.cs at the Solution Explorer and start debugging.
    public class PersonWebService : IPerson
    {
        public static List<Person> PersonList = new List<Person>();

        public void Create(string id, string firstname, string lastname)
        {
            Person result = new Person();
            result.Id = id;
            result.FirstName = firstname;
            result.LastName = lastname;
            PersonList.Add(result);
        }

        public void Delete(string id)
        {
            PersonList.Remove(PersonList.Where(x => x.Id == id).FirstOrDefault());
        }

        public string GetAll()
        {
            string list = "";
            foreach (Person se in PersonList)
            {
                list += se.Id + " " + se.FirstName + " " + se.LastName + System.Environment.NewLine;
            }
            return list;
        }

        public string GetById(string id)
        {
            string list = "";
            Person result = new Person();
            result = PersonList.Where(x => x.Id == id).FirstOrDefault();
            list = "ID: " + result.Id + System.Environment.NewLine + result.FirstName + result.LastName;
            return list;
        }

        public string SearchByLastName(string lastname)
        {
            Person result = new Person();
            result = PersonList.Where(x => x.LastName == lastname).FirstOrDefault();

            string list = "";
            list = "Last name: " + result.LastName + System.Environment.NewLine + result.Id + " " + result.FirstName;

            return list;
        }

        public void Update(string id, string firstname, string lastname)
        {
            Person result = new Person();
            result = PersonList.Where(x => x.Id == id).FirstOrDefault();
            PersonList.Remove(result);
            result.FirstName = firstname;
            result.LastName = lastname;
            PersonList.Add(result);
        }
    }
}
