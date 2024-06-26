using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf_Stationery;

namespace Alten_Stationery
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main= new MainWindow();
            BaseLayout home= new BaseLayout();
            main.Content = home;
            main.Show();
        }

        private void Link_ResetPassword(object sender, RoutedEventArgs e)
        {

        }
    }
}