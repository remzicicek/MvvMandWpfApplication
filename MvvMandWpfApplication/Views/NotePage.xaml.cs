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
    /// Interaction logic for NotePage.xaml
    /// </summary>
    public partial class NotePage : Window
    {
        public NotePage()
        {
            InitializeComponent();
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            LoginPage login = new LoginPage();
            login.Show();
            this.Close();
        }

    }
}
