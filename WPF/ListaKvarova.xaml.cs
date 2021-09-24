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
    /// Interaction logic for ListaKvarova.xaml
    /// </summary>
    public partial class ListaKvarova : Page
    {
        IKvar kvarServis = Factory.CreateKvarServis();
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
