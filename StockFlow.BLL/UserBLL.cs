using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockFlow.DAL;
using StockFlow.DTO;

namespace StockFlow.BLL
{
    public class UserBLL
    {
        UserDAL dal = new UserDAL();

        public UserDTO? Login(UserDTO user)
        {
            if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
                return null;

            return dal.Login(user.UserName, user.Password);
        }
        public bool Register(UserDTO user)
        {
            if (user == null ||
                string.IsNullOrEmpty(user.UserName) ||
                string.IsNullOrEmpty(user.Password))
                return false;

            // check trùng
            if (dal.CheckExist(user.UserName))
                return false;

            return dal.InsertUser(user);
        }
        public bool Update(UserDTO user)
        {
            if (user == null || string.IsNullOrEmpty(user.UserName))
                return false;
            return dal.UpdateUser(user);
        }
    }
}
