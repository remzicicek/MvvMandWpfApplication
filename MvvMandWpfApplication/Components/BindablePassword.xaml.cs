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

namespace MvvMandWpfApplication.Components
{
    /// <summary>
    /// Interaction logic for BindablePassword.xaml
    /// </summary>
    public partial class BindablePassword : UserControl
    {
        public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register("Password", typeof(string), typeof(BindablePassword), new PropertyMetadata(string.Empty));

        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        public BindablePassword()
        {
            InitializeComponent();
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Password = txtPassword.Password;
        }

    }
}
