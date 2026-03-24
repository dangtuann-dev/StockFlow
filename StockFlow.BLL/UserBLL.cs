using StockFlow.DAL;
using StockFlow.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockFlow.BLL
{
    public class UserBLL
    {
        private UserDAL userDAL = new UserDAL();

        public List<UserDTO> GetUserDTOs()
        {
            return userDAL.GetUserDTOs();
        }
    }
}
