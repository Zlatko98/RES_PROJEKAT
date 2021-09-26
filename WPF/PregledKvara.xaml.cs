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
    /// Interaction logic for PregledKvara.xaml
    /// </summary>
    public partial class PregledKvara : Page
    {
        IKvarServis kvarServis = Factory.CreateKvarServis();
        public PregledKvara()
        {
            InitializeComponent();
            elementBox.ItemsSource = kvarServis.GetElektricniElementi();
            elementBox.DisplayMemberPath = "GetIDnaziv";

            statusBox.ItemsSource = kvarServis.GetStatus();
        }

        private void Button_Click_AzurirajKvar(object sender, RoutedEventArgs e)
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
                Status status = (Status)Enum.Parse(typeof(Status), statusBox.SelectedItem.ToString());

                string id = idTxtBox.Text;

                kvarServis.AzurirajKvar(id, kratakOpis, uzrok, opis, status, vreme, akcija, element);
            }
        }



        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            ListaKvarova page = new ListaKvarova();
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

            if (kratakOpisBox.Text.Trim().Equals(""))
            {
                kratakOpisBox.BorderBrush = Brushes.Red;
                kvarLabel.Visibility = Visibility.Visible;
                result = false;
            }
            else
            {
                kratakOpisBox.BorderBrush = Brushes.Transparent;
                kvarLabel.Visibility = Visibility.Hidden;
            }
            if (akcijaBox.Text.Trim().Equals(""))
            {
                akcijaBox.BorderBrush = Brushes.Red;
                akcijaLabel.Visibility = Visibility.Visible;
                result = false;
            }
            else
            {
                akcijaBox.BorderBrush = Brushes.Transparent;
                akcijaLabel.Visibility = Visibility.Hidden;
            }

            if (uzrokBox.Text.Trim().Equals(""))
            {
                uzrokBox.BorderBrush = Brushes.Red;
                uzrokLabel.Visibility = Visibility.Visible;
                result = false;
            }
            else
            {
                uzrokBox.BorderBrush = Brushes.Transparent;
                uzrokLabel.Visibility = Visibility.Hidden;
            }

            if (opisBox.Text.Trim().Equals(""))
            {
                opisBox.BorderBrush = Brushes.Red;
                opisLabel.Visibility = Visibility.Visible;
                result = false;
            }
            else
            {
                opisBox.BorderBrush = Brushes.Transparent;
                opisLabel.Visibility = Visibility.Hidden;
            }

            if (!(elementBox.SelectedIndex > -1))
            {
                elementBox.BorderBrush = Brushes.Red;
                elementLabel.Visibility = Visibility.Visible;
                result = false;
            }
            else
            {
                elementBox.BorderBrush = Brushes.Transparent;
                elementLabel.Visibility = Visibility.Hidden;
            }

            return result;
        }
    }
}
