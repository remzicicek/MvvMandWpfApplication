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
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Window
    {
        UserViewModel userViewModel;
        public RegisterPage()
        {
            InitializeComponent();
            userViewModel = new UserViewModel();
            this.DataContext = userViewModel;
        }

        private void btnBackLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginPage login = new LoginPage();
            login.Show();
            this.Close();
        }

    }
}
