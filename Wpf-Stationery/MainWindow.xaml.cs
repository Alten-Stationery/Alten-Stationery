
using DBLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.IServices;
using System;
using System.Runtime;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
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

        private readonly UserManager<User> _userManager;
        private  SignInManager<User> _signInManager;

        
        public MainWindow()
        {
            InitializeComponent();
            _service =App.ServiceProvider.GetService<IUsersService>();
            _userManager = App.ServiceProvider.GetRequiredService<UserManager<User>>() ;
            _signInManager = App.ServiceProvider.GetRequiredService<SignInManager<User>>();
            _signInManager.Context = new DefaultHttpContext { RequestServices = App.ServiceProvider };
            this.DataContext = new User();
        }


        private async void Button_Click(object sender, RoutedEventArgs e)
        {


            Settings.Default.Save();

            try
            {
                var user = await _userManager.FindByEmailAsync(email.Text);
                if (user == null)
                {
                    MessageBox.Show("User not found.");
                    return;
                }

                //var check = await _signInManager.PasswordSignInAsync(user, password.Text, false, false);
                var check = await _userManager.CheckPasswordAsync(user,password.Text);
                if (check==true)
                {
                    var newWindow = new UserPage(_service);
                    this.Close();
                    newWindow.Show();   
                }
                else
                {
                    MessageBox.Show("Invalid login attempt.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }



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