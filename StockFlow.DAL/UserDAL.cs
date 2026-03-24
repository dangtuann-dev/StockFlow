using StockFlow.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockFlow.DAL
{
    public class UserDAL
    {
        public List<UserDTO> GetUserDTOs()
        {
            List<UserDTO> list = new List<UserDTO>();
            using (SqlConnection conn = DataAccess.GetConnection())
            {
                string query = "SELECT * FROM Users";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    UserDTO Us = new UserDTO
                    {
                        UserID = (int)reader["UserID"],
                        UserName = reader["UserName"].ToString(),
                        FullName = reader["FullName"].ToString(),
                        Password = reader["Password"].ToString(),
                        Phone = reader["Phone"].ToString()
                    };
                    list.Add(Us);
                }
            }
            return list;
        }
    }
}
