using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using FluentValidation.Results;

using MvvMandWpfApplication.Models;
using MvvMandWpfApplication.Services;
using MvvMandWpfApplication.Commands;
using MvvMandWpfApplication.Validators;

namespace MvvMandWpfApplication.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        UserService userService;

        public UserViewModel()
        {
            userService = new UserService();
            LoadData();
            CurrentUser = new UsersDTO();

            CommandCalls();
            ViewCalls();
        }

        private UsersDTO currentUser;

        public UsersDTO CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; OnPropertyChanged("CurrentUser"); }
        }

        #region RelayCommand command

        public void CommandCalls()
        {
            saveCommand = new RelayCommand(Save);

            userControlCommand = new RelayCommand(UserControl);
        }

        #endregion

        #region View geçişleri için

        public void ViewCalls()
        {
            // Switching between windows is done in the viewToview class.
            passView = new ViewToView();
        }

        #endregion

        #region DisplayOperation

        private ObservableCollection<UsersDTO> usersList;

        public ObservableCollection<UsersDTO> UsersList
        {
            get { return usersList; }
            set { usersList = value; OnPropertyChanged("UsersList"); }
        }

        private void LoadData()
        {
            UsersList = new ObservableCollection<UsersDTO>(userService.GetAll());
        }
        #endregion

        #region Message

        // To print extra warning messages
        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        #endregion

        #region SaveOperation for Register

        private RelayCommand saveCommand;

        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
        }

        public void Save()
        {
            try
            {
                bool IsSaved = false;

                UsersDTO temp = new UsersDTO();

                /// operations required for fluent validation
                RegisterValidator reg = new RegisterValidator(CurrentUser);
                ValidationResult results = reg.Validate(CurrentUser);


                if (!results.IsValid)
                {
                    Message = results.Errors[0].ToString();
                }
                else
                {
                    temp.Id = CurrentUser.Id;
                    temp.FirstName = CurrentUser.FirstName;
                    temp.LastName = CurrentUser.LastName;
                    temp.Email = CurrentUser.Email;
                    temp.Password = CurrentUser.Password;
                    temp.PasswordConfirm = CurrentUser.PasswordConfirm;
                    temp.UserName = CurrentUser.UserName;

                    if (!results.IsValid)
                    {
                        Message = results.Errors[0].ToString();
                    }
                    else
                    {
                        IsSaved = userService.Register(temp);
                        LoadData();
                    }
                }


                if (IsSaved)
                {
                    Message = "User saved";
                }

            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        #endregion

        #region UserControl for Login

        public bool IsLogin = false;

        private RelayCommand userControlCommand;

        public RelayCommand UserControlCommand
        {
            get { return userControlCommand; }
        }

        private ViewToView passView;

        public ViewToView PassView
        {
            get { return passView; }
        }


        public void UserControl()
        {

            try
            {
                UsersDTO temp = new UsersDTO();

                temp = userService.Search(CurrentUser.UserName);

                if(temp.Id != 0)
                {
                    if ((temp.UserName).Equals(CurrentUser.UserName) && (temp.Password).Equals(CurrentUser.Password))
                    {
                        passView.passToMainWindowFromLoginWindow(temp);
                    }
                }

                else
                {
                    Message = "Login Operation Failed";
                }

            }
            catch (Exception)
            {
                Message = "Login Operation Failed";
            }
        }

        #endregion

    }

}
