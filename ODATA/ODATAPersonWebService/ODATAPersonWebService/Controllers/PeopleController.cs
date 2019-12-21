using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using ODATAPersonWebService.Models;

namespace ODATAPersonWebService.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using ODATAPersonWebService.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Person>("People");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class PeopleController : ODataController
    {
        private ODATAPersonWebServiceContext db = new ODATAPersonWebServiceContext();

        // GET: odata/People
        [EnableQuery]
        public IQueryable<Person> GetPeople()
        {
            return db.People;
        }

        // GET: odata/People(5)
        [EnableQuery]
        public SingleResult<Person> GetPerson([FromODataUri] string key)
        {
            return SingleResult.Create(db.People.Where(person => person.Id == key));
        }

        // PUT: odata/People(5)
        public IHttpActionResult Put([FromODataUri] string key, Delta<Person> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Person person = db.People.Find(key);
            if (person == null)
            {
                return NotFound();
            }

            patch.Put(person);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(person);
        }

        // POST: odata/People
        public IHttpActionResult Post(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.People.Add(person);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PersonExists(person.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(person);
        }

        // PATCH: odata/People(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] string key, Delta<Person> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Person person = db.People.Find(key);
            if (person == null)
            {
                return NotFound();
            }

            patch.Patch(person);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(person);
        }

        // DELETE: odata/People(5)
        public IHttpActionResult Delete([FromODataUri] string key)
        {
            Person person = db.People.Find(key);
            if (person == null)
            {
                return NotFound();
            }

            db.People.Remove(person);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonExists(string key)
        {
            return db.People.Count(e => e.Id == key) > 0;
        }
    }
}
