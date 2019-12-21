using PersonWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PersonWebAPI.Controllers
{
    public class PersonController : ApiController
    {
        public static List<Person> PersonList = new List<Person>()
        {
            new Person { Id = "1", FirstName = "Tomato Soup", LastName = "aaa"},
            new Person { Id = "2", FirstName = "Yo-yo", LastName = "bbb"},
            new Person { Id = "3", FirstName = "Hammer", LastName = "ccc" }
        };

        //Person[] persons = new Person[]
        // {
        //    new Person { Id = "1", FirstName = "Tomato Soup", LastName = "aaa"},
        //    new Person { Id = "2", FirstName = "Yo-yo", LastName = "bbb"},
        //    new Person { Id = "3", FirstName = "Hammer", LastName = "ccc" }
        // };

        [HttpPost]
        [Route("api/person/{Id}_created")]
        public void Create([FromBody]Person person)
        {
            PersonList.Add(person);
        }

        [HttpDelete]
        [Route("api/person/{Id}_deleted")]
        public void Delete(string id)
        {
            PersonList.Remove(PersonList.Where(x => x.Id == id).FirstOrDefault());
            var response = Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        public IEnumerable<Person> GetAll()
        { 
            return PersonList;
        }

        [HttpGet]
        public Person GetById(string id)
        {
            Person result = new Person();
            result = PersonList.Where(x => x.Id == id).FirstOrDefault();
            return result;
        }


        [Route("api/person/{LastName}_")]
        public Person GetSearchByLastName(string lastname)
        {
            Person result = new Person();
            result = PersonList.Where(x => x.LastName == lastname).FirstOrDefault();
            return result;
        }

        [HttpPut] 
        [Route("api/person/{Id}_updated")]
        public void Update([FromBody]Person person)
        {
            Person result = new Person();
            result = PersonList.Where(x => x.Id == person.Id).FirstOrDefault();
            //PersonList.Remove(result);
            if (result.FirstName != person.FirstName && person.FirstName != "")
            {
                result.FirstName = person.FirstName;
            }
            if (result.LastName != person.LastName && person.LastName != "")
            {
                result.LastName = person.LastName;
            }
        }


    }
}
