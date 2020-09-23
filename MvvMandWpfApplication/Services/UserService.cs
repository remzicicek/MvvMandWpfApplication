using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using MvvMandWpfApplication.Models;

namespace MvvMandWpfApplication.Services
{
    public class UserService
    {
        UserDBEntities ObjContext; //to get from the database

        public UserService()
        {
            ObjContext = new UserDBEntities();
        }

        #region Get all user from the database

        public List<UsersDTO> GetAll()
        {
            List<UsersDTO> userList = new List<UsersDTO>();

            try
            {
                var ObjQuery = from user in ObjContext.Users
                               select user;

                foreach (var user in ObjQuery)
                {
                    userList.Add(new UsersDTO { Id = user.Id, FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, Password = user.Password, UserName = user.UserName });
                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return userList;
        }

        #endregion

        #region User Registered

        public bool Register(UsersDTO newUser)
        {
            bool IsAdded = false;

            try
            {
                var ObjUser = new User(); // class of database user table

                ObjUser.Id = newUser.Id;
                ObjUser.FirstName = newUser.FirstName;
                ObjUser.LastName = newUser.LastName;
                ObjUser.Email = newUser.Email;
                ObjUser.Password = newUser.Password;
                ObjUser.UserName = newUser.UserName;

                ObjContext.Users.Add(ObjUser);

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

        #region User Searching

        public UsersDTO Search(string userName)
        {
            UsersDTO newUser = new UsersDTO();

            try
            {
                var ObjUserToFind = ObjContext.Users
                                    .Where(u => u.UserName == userName)
                                    .FirstOrDefault();

                if (ObjUserToFind != null)
                {
                    newUser = new UsersDTO()
                    {
                        Id = ObjUserToFind.Id,
                        FirstName = ObjUserToFind.FirstName,
                        LastName = ObjUserToFind.LastName,
                        Email = ObjUserToFind.Email,
                        Password = ObjUserToFind.Password,
                        UserName = ObjUserToFind.UserName
                    };
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return newUser;
        }

        #endregion

    }

}
