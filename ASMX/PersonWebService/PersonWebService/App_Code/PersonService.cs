using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;


/// <summary>
/// Summary description for PersonService
/// </summary>
[WebService(Namespace = "http://korag.cba.pl/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class PersonService : System.Web.Services.WebService
{
    public static List<Person> PersonList = new List<Person>();


    //public PersonService()
    //{

    //    //Uncomment the following line if using designed components 
    //    //InitializeComponent(); 
    //}

    [WebMethod]
    public string GetAll()
    {
        string list = "";
        foreach (Person se in PersonList)
        {
            list += se.Id + " " + se.FirstName + " " + se.LastName + System.Environment.NewLine;
        }
        return list;
    }

    [WebMethod]
    public string GetById(string id)
    {
       string list = "";
       Person result = new Person();
       result = PersonList.Where(x => x.Id == id).FirstOrDefault();
       list = "ID: " + result.Id + System.Environment.NewLine + result.FirstName + result.LastName;
       return list;
    }

    [WebMethod]
    public void Create(string id, string firstname, string lastname)
    {
        Person result = new Person();
        result.Id = id;
        result.FirstName = firstname;
        result.LastName = lastname;
        PersonList.Add(result);
    }

    [WebMethod]
    public void Update(string id, string firstname, string lastname)
    {
        Person result = new Person();
        result = PersonList.Where(x => x.Id == id).FirstOrDefault();
        PersonList.Remove(result);
        result.FirstName = firstname;
        result.LastName = lastname;
        PersonList.Add(result);
    }

    [WebMethod]
    public void Delete(string id)
    {
        PersonList.Remove(PersonList.Where(x=>x.Id==id).FirstOrDefault());
    }

    [WebMethod]
    public string SearchByLastName(string lastname)
    {
        Person result = new Person();
        result = PersonList.Where(x => x.LastName == lastname).FirstOrDefault();

        string list = "";
        list = "Last name: " + result.LastName + System.Environment.NewLine + result.Id + " " + result.FirstName;

        return list;
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

}
