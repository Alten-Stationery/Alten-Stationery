using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Alten_Stationery
{
    public static class PlaceholderBehavior
    {

        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.RegisterAttached(
                "Placeholder",
                typeof(string),
                typeof(PlaceholderBehavior),
                new PropertyMetadata(string.Empty, OnPlaceholderChanged));

        public static string GetPlaceholder(UIElement element)
        {
            return (string)element.GetValue(PlaceholderProperty);
        }

        public static void SetPlaceholder(UIElement element, string value)
        {
            element.SetValue(PlaceholderProperty, value);
        }

        private static void OnPlaceholderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBox textBox)
            {
                textBox.TextChanged -= TextBox_TextChanged;
                textBox.GotFocus -= TextBox_GotFocus;
                textBox.LostFocus -= TextBox_LostFocus;

                if (!string.IsNullOrEmpty((string)e.NewValue))
                {
                    textBox.TextChanged += TextBox_TextChanged;
                    textBox.GotFocus += TextBox_GotFocus;
                    textBox.LostFocus += TextBox_LostFocus;
                    SetPlaceholder(textBox);
                }
            }
            else if (d is PasswordBox passwordBox)
            {
                passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;
                passwordBox.GotFocus -= PasswordBox_GotFocus;
                passwordBox.LostFocus -= PasswordBox_LostFocus;

                if (!string.IsNullOrEmpty((string)e.NewValue))
                {
                    passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
                    passwordBox.GotFocus += PasswordBox_GotFocus;
                    passwordBox.LostFocus += PasswordBox_LostFocus;
                    SetPlaceholder(passwordBox);
                }
            }
        }

        private static void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetPlaceholder(sender as TextBox);
        }

        private static void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Text == GetPlaceholder(textBox))
            {
                textBox.Text = string.Empty;
                textBox.Foreground = SystemColors.WindowTextBrush;
            }
        }

        private static void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            SetPlaceholder(sender as TextBox);
        }

        private static void SetPlaceholder(TextBox textBox)
        {
            if (textBox != null && string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = GetPlaceholder(textBox);
                textBox.Foreground = SystemColors.GrayTextBrush;
            }
        }

        private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            SetPlaceholder(sender as PasswordBox);
        }

        private static void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox && passwordBox.Password == GetPlaceholder(passwordBox))
            {
                passwordBox.Password = string.Empty;
                passwordBox.Foreground = SystemColors.WindowTextBrush;
            }
        }

        private static void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            SetPlaceholder(sender as PasswordBox);
        }

        private static void SetPlaceholder(PasswordBox passwordBox)
        {
            if (passwordBox != null && string.IsNullOrEmpty(passwordBox.Password))
            {
                passwordBox.Password = GetPlaceholder(passwordBox);
                passwordBox.Foreground = SystemColors.GrayTextBrush;
            }
        }

    }
}