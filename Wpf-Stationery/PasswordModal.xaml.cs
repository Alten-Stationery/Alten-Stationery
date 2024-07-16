using DBLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.IServices;
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

namespace Wpf_Stationery
{
    /// <summary>
    /// Interaction logic for PasswordModal.xaml
    /// </summary>
    public partial class PasswordModal : Window
    {
        private IUsersService _service;
        private UserManager<User> _userManager;
        private User _user;
        public PasswordModal(User user)
        {
            InitializeComponent();
            _userManager = App.ServiceProvider.GetRequiredService<UserManager<User>>();
            _service= App.ServiceProvider.GetService<IUsersService>();
            _user= user;
            this.DataContext=_user;
        }

        private void PassOld_Loaded(object sender, RoutedEventArgs e)
        {
            passOld.Text = "Old Password";
        }

        private void PassOld_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(passOld.Text))
                passOld.Text = "Old Password";
        }

        private void PassOld_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (passOld.Text == "Old Password")
                passOld.Text = "";
        }

        private void PassOld_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (passOld.Text == "Old Password")
                passOld.Text = "";
        }

        private void PassNew_Loaded(object sender, RoutedEventArgs e)
        {
            passNew.Text = "New Password";
        }

        private void PassNew_MouseLeave(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(passNew.Text))
                passNew.Text = "New Password";
        }

        private void PassNew_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (passNew.Text == "New Password")
                passNew.Text = "";
        }

        private void PassNew_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (passNew.Text == "New Password")
                passNew.Text = "";
        }

        private void PassNew2_Loaded(object sender, RoutedEventArgs e)
        {
            passNew2.Text = "Confirm Password";
        }

        private void PassNew2_MouseLeave(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(passNew2.Text))
                passNew2.Text = "Confirm Password";
        }

        private void PassNew2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (passNew2.Text == "Confirm Password")
                passNew2.Text = "";
        }

        private void PassNew2_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (passNew2.Text == "Confirm Password")
                passNew2.Text = "";
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (passNew.Text == passNew2.Text)
                {
                    await _userManager.ChangePasswordAsync(_user, passOld.Text, passNew.Text);
                }
                      
            }catch(Exception ex) 
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
