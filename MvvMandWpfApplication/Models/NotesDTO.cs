using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MvvMandWpfApplication.Models
{
    public class NotesDTO : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

        private string note;

        public string Note
        {
            get { return note; }
            set { note = value; OnPropertyChanged("Note"); }
        }

        private int userId;

        public int UserId
        {
            get { return userId; }
            set { userId = value; OnPropertyChanged("UserId"); }
        }


    }

}
