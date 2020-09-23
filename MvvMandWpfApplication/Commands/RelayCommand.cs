using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using MvvMandWpfApplication.Views;

namespace MvvMandWpfApplication.Commands
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action DoWork;

        // Obje oluşturulurken çalışacak fonk ismi buraya gelir
        public RelayCommand(Action work)
        {
            DoWork = work;
        }

        public bool CanExecute(object parameter)
        {

            return true; // istediğin event olayını burada aktif edebilirsin şimdilik hepsi aktif
        }

        public void Execute(object parameter)
        {

            DoWork();
        }
    }

}
