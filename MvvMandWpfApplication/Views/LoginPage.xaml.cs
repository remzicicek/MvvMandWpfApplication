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
using System.Windows.Shapes;

using MvvMandWpfApplication.ViewModels;

namespace MvvMandWpfApplication.Views
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        UserViewModel userViewModel;
        public LoginPage()
        {
            InitializeComponent();
            userViewModel = new UserViewModel();
            this.DataContext = userViewModel;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterPage reg = new RegisterPage();
            reg.Show();
            this.Close();
        }

    }
}
