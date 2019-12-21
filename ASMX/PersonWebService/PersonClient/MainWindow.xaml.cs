using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using PersonClient.localhost;

namespace PersonClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PersonService PS = new PersonService();

        public MainWindow()
        {
       
            InitializeComponent();
        }

        private void GetAll_Click(object sender, RoutedEventArgs e)
        {
            LIST.Text = PS.GetAll();
        }

        private void GetByID_Click(object sender, RoutedEventArgs e)
        {
            LIST.Text = PS.GetById(Search.Text);
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            PS.Update(Search.Text, FirstName.Text, LastName.Text);
        }

        private void SearchByLastName_Click(object sender, RoutedEventArgs e)
        {
            LIST.Text = PS.SearchByLastName(Search.Text);
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            PS.Create(ID.Text, FirstName.Text, LastName.Text);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            PS.Delete(Search.Text);
        }
    }
}
