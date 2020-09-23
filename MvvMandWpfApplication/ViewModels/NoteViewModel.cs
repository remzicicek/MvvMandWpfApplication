using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using MvvMandWpfApplication.Models;
using MvvMandWpfApplication.Services;
using MvvMandWpfApplication.Commands;

namespace MvvMandWpfApplication.ViewModels
{
    public class NoteViewModel : ViewModelBase
    {
        NoteService noteService;

        // To get the user using the account from userview, user is taken as the parameter. It is sent to the User viewToView class and sent as a parameter to the noteview object created there.
        public NoteViewModel(UsersDTO user)
        {
            noteService = new NoteService(user.Id);

            LoadNote();

            CurrentNote = new NotesDTO();
            SessionUser = user;  // the user using the account is taken and assigned to the sessionUser variable
            callCommands();
        }

        private NotesDTO currentNote;

        public NotesDTO CurrentNote
        {
            get { return currentNote; }
            set { currentNote = value; OnPropertyChanged("CurrentNote"); }
        }

        private UsersDTO sessionUser;

        public UsersDTO SessionUser
        {
            get { return sessionUser; }
            set { sessionUser = value; OnPropertyChanged("SessionUser"); }
        }

        // Required parameters for Relay command are created here.
        #region RelayCommand command

        public void callCommands()
        {
            saveCommandNote = new RelayCommand(SaveNote);
            deleteCommandNote = new RelayCommand(DeleteNote);
            updateCommandNote = new RelayCommand(UpdateNote);
        }

        #endregion

        #region DisplayOperation

        private ObservableCollection<NotesDTO> notesList;

        public ObservableCollection<NotesDTO> NotesList
        {
            get { return notesList; }
            set { notesList = value; OnPropertyChanged("NotesList"); }
        }

        private void LoadNote()
        {
            NotesList = new ObservableCollection<NotesDTO>(noteService.GetUserNote());
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

        #region SaveOperation

        private RelayCommand saveCommandNote;

        public RelayCommand SaveCommandNote
        {
            get { return saveCommandNote; } 
        }

        public void SaveNote()
        {
            try
            {
                NotesDTO temp = new NotesDTO();

                // New object created to prevent reference
                if (CurrentNote.Note != null)
                {

                    temp.Note = CurrentNote.Note;
                    temp.UserId = SessionUser.Id;

                    var IsSaved = noteService.AddNote(temp);
                    LoadNote();

                    CurrentNote = new NotesDTO(); //After adding note, the note in the textbox is deleted and creates a new object to enter a new note.

                    if (IsSaved)
                        Message = "Note saved";
                    else
                        Message = "Save Operation Failed";
                }
                else
                {
                    Message = "Note is empty. So Save operation failed !";
                }

            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        #endregion

        #region DeleteOperation

        private RelayCommand deleteCommandNote;

        public RelayCommand DeleteCommandNote
        {
            get { return deleteCommandNote; }
        }

        public void DeleteNote()
        {
            try
            {
                var IsDelete = noteService.Delete(CurrentNote.Id);

                if (IsDelete)
                {
                    Message = "Note Deleted";
                    LoadNote();
                    CurrentNote = new NotesDTO(); // After delete operation currentNote is null and cannot get input from UI. Therefore, the new object is opened.

                }
                else
                    Message = "Delete Operation Failed";
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        #endregion

        #region UpdateOperation

        private RelayCommand updateCommandNote;

        public RelayCommand UpdateCommandNote
        {
            get { return updateCommandNote; } 
        }

        public void UpdateNote()
        {
            try
            {
                if (CurrentNote.Note != null)
                {
                    NotesDTO temp = new NotesDTO();
                    temp.Id = CurrentNote.Id;
                    temp.Note = CurrentNote.Note;
                    temp.UserId = CurrentNote.UserId;

                    var IsUpdate = noteService.Update(temp);
                    if (IsUpdate)
                    {
                        LoadNote();
                        CurrentNote = new NotesDTO();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }

}
