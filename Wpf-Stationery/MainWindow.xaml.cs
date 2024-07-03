
using DBLayer.Models;
using Microsoft.AspNetCore.Identity;
using ServiceLayer.IServices;
using System.Windows;
using Wpf_Stationery;
using Wpf_Stationery.Properties;

namespace Alten_Stationery
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IUsersService _service;
        User user;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
     

        public MainWindow(IUsersService service, UserManager<User> userManager,SignInManager<User> signInManager)
        {
            _service = service;
            InitializeComponent();
            _userManager = userManager;
            _signInManager = signInManager;
            this.DataContext = user;
        }



        private void Link_ResetPassword(object sender, RoutedEventArgs e)
        {

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default.Save();


            MainWindow main = new MainWindow(_service, _userManager,_signInManager) ;

            User user = new User()
            {
                Email = email.Text,

            };
            var check = _signInManager.PasswordSignInAsync(user, password.Text, false, false);
            if (check.IsCompletedSuccessfully)
            {
                UserPage userPage = new UserPage(_service);
                main.Content = userPage;
            }



            main.Show();


        }

        private void password_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            
        }

        //private void CheckBox_CheckedChanged(object sender, RoutedEventArgs e)
        //{
        //    if(check.Checked)
        //    {

        //    }
        //}
    }
}