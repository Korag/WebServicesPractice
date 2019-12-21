using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Summary description for Person
/// </summary>
/// 
[DataContract]
public class Person
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Person()
    {

    }
}