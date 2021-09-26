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
    /// Interaction logic for Evidencija.xaml
    /// </summary>
    public partial class Evidencija : Page
    {
        IKvarServis kvarServis = Factory.CreateKvarServis();
        public Evidencija()
        {
            InitializeComponent();

            evidencijaBox.ItemsSource = null;
            evidencijaBox.ItemsSource = kvarServis.GetElektricniElementi();
            evidencijaBox.DisplayMemberPath = "Display";
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
    }
}
