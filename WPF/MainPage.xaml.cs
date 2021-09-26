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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click_ListaKvarova(object sender, RoutedEventArgs e)
        {
            ListaKvarova page = new ListaKvarova();
            NavigationService.Navigate(page);
        }

        private void Button_Click_UnosKvara(object sender, RoutedEventArgs e)
        {
            UnosKvara page = new UnosKvara();
            NavigationService.Navigate(page);
        }

        private void Button_Click_Evidencija(object sender, RoutedEventArgs e)
        {
            Evidencija page = new Evidencija();
            NavigationService.Navigate(page);
        }

        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }
    }
}
