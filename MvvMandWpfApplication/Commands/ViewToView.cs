using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MvvMandWpfApplication.Models;
using MvvMandWpfApplication.Views;
using MvvMandWpfApplication.ViewModels;


namespace MvvMandWpfApplication.Commands
{
    public class ViewToView
    {
        public void passToMainWindowFromLoginWindow(UsersDTO user)
        {

            NotePage notePage = new NotePage();
            notePage.DataContext = new NoteViewModel(user); // datacontext ile viewModeli page açılacağı zaman bağlar. Bağlarken userViewModelden current kullanıcıyı da alır.
            notePage.Show();

            System.Windows.Application.Current.MainWindow.Close();
        }
    }

}
