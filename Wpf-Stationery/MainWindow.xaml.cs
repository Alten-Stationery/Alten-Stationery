using DBLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ServiceLayer.IServices;
using System;
using System.Runtime;
using System.Windows;
using System.Windows.Threading;

using Wpf_Stationery;
using Wpf_Stationery.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Alten_Stationery
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IUsersService _service;

        private readonly UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private User user;

        public MainWindow()
        {
            InitializeComponent();
            _service = App.ServiceProvider.GetService<IUsersService>();
            _userManager = App.ServiceProvider.GetRequiredService<UserManager<User>>();
            _signInManager = App.ServiceProvider.GetRequiredService<SignInManager<User>>();
            _signInManager.Context = new DefaultHttpContext { RequestServices = App.ServiceProvider };
            this.DataContext = new User();
        }


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default.Save();

            try
            {
                //var user = await _userManager.FindByEmailAsync(email.Text);
                //if (user == null)
                //{
                //    MessageBox.Show("User not found.");
                //    return;
                //}

                //var check = await _signInManager.PasswordSignInAsync(user, password.Text, false, false);
                //var check = await _userManager.CheckPasswordAsync(user, password.Text);

                //if (check == true)
                //{
                    var newWindow = new UserPage(user);
                    this.Close();
                    newWindow.Show();
                //}
                //else
                //{
                //    MessageBox.Show("Invalid login attempt.");
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

        }








        private void email_Loaded(object sender, RoutedEventArgs e)
        {
            email.Text = "Email";


        }


        private void email_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (email.Text.IsNullOrEmpty())
                email.Text = "Email";
        }


        private void email_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (email.Text == "Email")
                email.Text = "";
        }

        private void email_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (email.Text == "Email")
                email.Text = "";
        }

        private void password_Loaded(object sender, RoutedEventArgs e)
        {
            password.Text = "Password";
        }

        private void password_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (password.Text.IsNullOrEmpty())
                password.Text = "Password";
        }

        private void password_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (password.Text == "Password")
                password.Text = "";
        }

        private void password_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (password.Text == "Password")
                password.Text = "";
        }
    }
}
