using Common;
using Servis;
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

namespace WPF
{
    /// <summary>
    /// Interaction logic for UnosKvara.xaml
    /// </summary>
    public partial class UnosKvara : Page
    {
        IKvar kvarServis = Factory.CreateKvarServis();

        public UnosKvara()
        {
            InitializeComponent();
            DataContext = this;
            elementBox.ItemsSource = kvarServis.GetElektricniElementi();
            elementBox.DisplayMemberPath = "GetIDnaziv";
        }

        private void Button_Click_DodajKvar(object sender, RoutedEventArgs e)
        {
            bool res = validation();

            if (res)
            {
                string kratakOpis = kratakOpisBox.Text;
                DateTime vreme = (DateTime)dateBox.SelectedDate;
                string akcija = akcijaBox.Text;
                string uzrok = uzrokBox.Text;
                string element = elementBox.Text;
                string opis = opisBox.Text;

                kvarServis.unesiKvar(kratakOpis, uzrok, opis, vreme, akcija, element);
            }
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            MainPage page = new MainPage();
            NavigationService.Navigate(page);
        }

        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }



        private bool validation()
        {
            bool result = true;

            return result;
        }
    }
}
