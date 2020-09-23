using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MvvMandWpfApplication.Models;

namespace MvvMandWpfApplication.Services
{
    public class NoteService
    {
        UserDBEntities ObjContext; //to get from the database

        int userıd;
        public NoteService(int id)
        {
            ObjContext = new UserDBEntities();
            userıd = id;
        }

        #region Get user's note from the database

        public List<NotesDTO> GetUserNote()
        {
            List<NotesDTO> noteList = new List<NotesDTO>();

            try
            {
                // get from the database
                var ObjQuery = from note in ObjContext.Notes
                               where note.UserId == userıd
                               select note;

                foreach (var note in ObjQuery)
                {
                    noteList.Add(new NotesDTO { Id = note.Id, Note = note.Note1, UserId = note.UserId });
                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return noteList;
        }

        #endregion

        #region Add note

        public bool AddNote(NotesDTO newNote)
        {
            bool IsAdded = false;
            try
            {
                var ObjNote = new Note(); // class of database note table

                ObjNote.Id = newNote.Id;
                ObjNote.Note1 = newNote.Note;
                ObjNote.UserId = newNote.UserId;

                ObjContext.Notes.Add(ObjNote);

                var NoOfRowsAffected = ObjContext.SaveChanges();

                IsAdded = NoOfRowsAffected > 0;

            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return IsAdded;
        }

        #endregion

        #region Delete note

        public bool Delete(int id)
        {
            bool IsDelete = false;

            try
            {
                var DeletedNote = ObjContext.Notes.Find(id);

                ObjContext.Notes.Remove(DeletedNote);

                var NoOfRowsAffected = ObjContext.SaveChanges();

                IsDelete = NoOfRowsAffected > 0;
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return IsDelete;
        }

        #endregion

        #region Update Note

        public bool Update(NotesDTO newNote)
        {
            bool IsUpdate = false;

            try
            {
                var updatedNote = ObjContext.Notes.Find(newNote.Id);
                updatedNote.Note1 = newNote.Note;

                var NoOfRowsAffected = ObjContext.SaveChanges();
                IsUpdate = NoOfRowsAffected > 0;
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return IsUpdate;
        }

        #endregion

    }

}
