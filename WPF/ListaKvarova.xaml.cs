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
using Common;
using Servis;

namespace WPF
{
    /// <summary>
    /// Interaction logic for ListaKvarova.xaml
    /// </summary>
    public partial class ListaKvarova : Page
    {
        IKvarServis kvarServis = Factory.CreateKvarServis();
        IExport exportServis = Factory.CreateExportServis();
        public ListaKvarova()
        {
            InitializeComponent();
        }
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            MainPage page = new MainPage();
            NavigationService.Navigate(page);
        }

        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            var window = (MainWindow)Application.Current.MainWindow;

            window.Close();
        }

        private void Button_Click_Export_W(object sender, RoutedEventArgs e)
        {
            Kvar kvar = new Kvar();

            kvar = (Kvar)ListBoxKvarovi.SelectedItem;

            exportServis.ExportToWord(kvar);

        }

        private void Button_Click_Export_Ex(object sender, RoutedEventArgs e)
        {
            List<Kvar> list = new List<Kvar>();

            foreach (var item in ListBoxKvarovi.Items)
            {
                list.Add((Kvar)item);
            }

            exportServis.ExportToExcel(list);
        }
        private void Button_Click_Prikazi_Kvar(object sender, RoutedEventArgs e)
        {
            Kvar kvar = new Kvar();

            kvar = (Kvar)ListBoxKvarovi.SelectedItem;

            PregledKvara page = new PregledKvara();

            page.kratakOpisBox.Text = kvar.KratakOpis;
            page.akcijaBox.Text = kvar.Akcija.Opis;
            page.uzrokBox.Text = kvar.Uzrok;
            page.opisBox.Text = kvar.DetaljanOpis;
            page.idTxtBox.Text = kvar.Id;
            page.dateBox.SelectedDate = kvar.Akcija.Vreme;
            page.elementBox.SelectedItem = kvar.IdElement.ToString() + kvar.ElektricniElement;
            page.statusBox.SelectedItem = kvar.Status.ToString();


            if (kvar.Status == Status.ZATVORENO)
            {
                page.uzrokBox.IsReadOnly = true;
                page.opisBox.IsReadOnly = true;
                page.idTxtBox.IsReadOnly = true;
                page.kratakOpisBox.IsReadOnly = true;
                page.akcijaBox.IsReadOnly = true;
                page.dateBox.IsEnabled = false;
                page.elementBox.IsEnabled = false;
                page.statusBox.IsEnabled = false;
            }

            NavigationService.Navigate(page);

        }

        private void Button_Click_Calculate(object sender, RoutedEventArgs e)
        {
            ListBoxKvarovi.ItemsSource = null;

            DateTime date1 = (DateTime)DPicker1.SelectedDate;
            DateTime date2 = (DateTime)DPicker2.SelectedDate;

            ListBoxKvarovi.ItemsSource = kvarServis.GetKvarovi(date1, date2);
            ListBoxKvarovi.DisplayMemberPath = "FullInfo";

        }
    }
}
