using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using Alten_Stationery;

namespace Wpf_Stationery
{
    public class ViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        // Close App
        public void CloseApp(object obj)
        {
            MainWindow win = obj as MainWindow;
            win.Close();
        }


        // Close App Command
        private ICommand _closeCommand;

        public ICommand CloseAppCommand
        {
            get
            {
                if (_closeCommand == null)
                {
                    _closeCommand = new RelayCommand(p => CloseApp(p));
                }
                return _closeCommand;
            }
        }

        // Maximize App
        public void MaxApp(object obj)
        {
            MainWindow win = obj as MainWindow;

            if (win.WindowState == WindowState.Normal)
            {
                win.WindowState = WindowState.Maximized;
            }
            else if (win.WindowState == WindowState.Maximized)
            {
                win.WindowState = WindowState.Normal;
            }
        }

        // Maximize App Command
        private ICommand _maxCommand;
        public ICommand MaxAppCommand
        {
            get
            {
                if (_maxCommand == null)
                {
                    _maxCommand = new RelayCommand(p => MaxApp(p));
                }
                return _maxCommand;
            }
        }

        public void MainViewModel()
        {
            // Set SideMenu Visibility 
            IsPanelVisible = false;
        }

        // Close Menu
        public void CloseMenu()
        {
            IsPanelVisible = false;
        }

        // Show Menu
        public void ShowMenu()
        {
            IsPanelVisible = true;
        }

        // Show Menu Command
        private ICommand _showMenuCommand;

        public ICommand ShowMenuCommand
        {
            get
            {
                if (_showMenuCommand == null)
                {
                    _showMenuCommand = new RelayCommand(p => ShowMenu());
                }
                return _showMenuCommand;
            }
        }


        // Close Menu Command
        private ICommand _closeMenuCommand;

        public ICommand CloseMenuCommand
        {
            get
            {
                if (_closeMenuCommand == null)
                {
                    _closeMenuCommand = new RelayCommand(p => CloseMenu());
                }
                return _closeMenuCommand;
            }
        }

        private bool _isPanelVisible;
        public bool IsPanelVisible
        {
            get
            {
                return _isPanelVisible;
            }
            set
            {
                _isPanelVisible = value;
                OnPropertyChanged("IsPanelVisible");
            }
        }
    }
}
