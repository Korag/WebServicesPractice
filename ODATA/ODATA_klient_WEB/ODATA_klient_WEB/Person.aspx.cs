using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ODATAPersonWebService.Models;

namespace ODATA_klient_WEB
{
    public partial class Person : System.Web.UI.Page
    {
        public static string Uri = "http://localhost:58916/odata/";
        public static Container proxy = new Container(new Uri(Uri));

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowCollection();

            proxy.SendingRequest2 += (s, f) =>
            {
                ListItem li = new ListItem();
                li.Text = f.RequestMessage.Method + " , " +  f.RequestMessage.Url;
                message.Items.Add(li);
            };
        }

        protected void ShowCollection()
        {
            var peopleCollection = proxy.People.ToList();

            persons.Items.Clear();

            foreach (var person in peopleCollection)
            {
                string PersonDetails = person.Id + " , " + person.FirstName + " , " + person.LastName;

                ListItem li = new ListItem();
                li.Text = PersonDetails;
                persons.Items.Add(li);
            }
        }

        protected void GETBYID(object sender, EventArgs e)
        {
            personget.Items.Clear();
            ListItem li = new ListItem();

            try
            {
                var pers = proxy.People.Where(x => x.Id == GetID.Text).FirstOrDefault();
                li.Text = pers.Id + " , " + pers.FirstName + " , " + pers.LastName;
            }
            catch (Exception)
            {
                li.Text = "Nie ma takiej osoby";
            }
            personget.Items.Add(li);
        }

        protected void SEARCHBYNAME(object sender, EventArgs e)
        {
            personsearch.Items.Clear();
            ListItem li = new ListItem();

            var pers = proxy.People.Where(x => x.LastName == SearchName.Text).ToList();

            if (pers.Count()!=0)
            {
                foreach (var person in pers)
                {
                    li.Text = person.Id + " , " + person.FirstName + " , " + person.LastName;
                    personsearch.Items.Add(li);
                }
            }
            else
            {
                li.Text = "Nie ma takiej osoby";
                personsearch.Items.Add(li);
            }
        }

        protected void CREATE(object sender, EventArgs e)
        {

            if (Id_cr.Text != "" && FirstName_cr.Text != "" && LastName_cr.Text != "")
            {
                ODATAPersonWebService.Models.Person created = new ODATAPersonWebService.Models.Person();
                created.Id = Id_cr.Text;
                created.FirstName = FirstName_cr.Text;
                created.LastName = LastName_cr.Text;

                ListItem li = new ListItem();

                try
                {
                    var pers = proxy.People.Where(x => x.Id == Id_cr.Text).ToList();
                    li.Text = $"Osoba o takim ID już istnieje w kolekcji: ID={pers[0].Id},{pers[0].FirstName}, {pers[0].LastName}";
                }
                catch (Exception)
                {
                    proxy.AddToPeople(created);
                    li.Text = created.Id + " , " + created.FirstName + " , " + created.LastName;
                }
              
                CrUpList.Items.Add(li);
                proxy.SaveChanges();
                ShowCollection();
            }         
        }

        protected void UPDATE(object sender, EventArgs e)
        {
            if (Id_cr.Text != "" && FirstName_cr.Text != "" && LastName_cr.Text != "")
            {
                ListItem li = new ListItem();

                try
                {
                    var pers = proxy.People.Where(x => x.Id == Id_cr.Text).FirstOrDefault();
                    pers.FirstName = FirstName_cr.Text;
                    pers.LastName = LastName_cr.Text;

                    li.Text = $"Dane osoby o ID={pers.Id} zostały zaktualizowane: ID={pers.Id}, Nowe dane={pers.FirstName}, {pers.LastName}";
                }
                catch (Exception)
                {
                    li.Text = $"Osoba o takim ID nie istnieje w kolekcji: ID={Id_cr.Text}";
                }

                CrUpList.Items.Add(li);
                proxy.SaveChanges();
                ShowCollection();
            }
        }

        protected void DELETE(object sender, EventArgs e)
        {
            ListItem li = new ListItem();

            try
            {
                var deleted = proxy.People.Where(x => x.Id == DelInput.Text).FirstOrDefault();

                proxy.DeleteObject(deleted);
                proxy.SaveChanges();

                li.Text = $"{deleted.Id},{deleted.FirstName}, {deleted.LastName}";
                ShowCollection();
            }
            catch (Exception)
            {
                li.Text = $"Osoba o takim ID nie istnieje w kolekcji: ID={DelInput.Text}";
            }

            DelList.Items.Add(li);
        }
    }
}