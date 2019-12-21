using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for Kalkulator
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Kalkulator : System.Web.Services.WebService
{

    public Kalkulator()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
     
    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public int Add(int A, int B)
    {
        return (A + B);
    }

    [WebMethod]
    public System.Single Subtract(System.Single A, System.Single B)
    {
        return (A - B);
    }

    [WebMethod]
    public System.Single Multiply(System.Single A, System.Single B)
    {
        return A * B;
    }

    [WebMethod]
    public System.Single Divide(System.Single A, System.Single B)
    {
        if (B == 0)
            return -1;
        return Convert.ToSingle(A / B);
    }

}
