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


        // Helper: kiểm tra cột có tồn tại trong reader không
        private static bool HasColumn(SqlDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
                if (reader.GetName(i).Equals(columnName, StringComparison.OrdinalIgnoreCase))
                    return true;
            return false;
        }

        public UserDTO Login(string username, string password)
        {
            using (SqlConnection conn = DataAccess.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Users WHERE UserName=@u AND Password=@p";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new UserDTO()
                    {
                        UserID   = reader["UserID"] != DBNull.Value ? (int)reader["UserID"] : 0,
                        UserName = reader["UserName"].ToString(),
                        FullName = HasColumn(reader, "FullName") && reader["FullName"] != DBNull.Value ? reader["FullName"].ToString() : "",
                        Password = reader["Password"].ToString(),
                        Phone    = HasColumn(reader, "Phone") && reader["Phone"] != DBNull.Value ? reader["Phone"].ToString() : "",
                        Role     = HasColumn(reader, "Role") && reader["Role"] != DBNull.Value ? reader["Role"].ToString() : "admin"
                    };
                }
                return null;
            }
        }

        public List<UserDTO> GetAllUsers()
        {
            List<UserDTO> list = new List<UserDTO>();
            using (SqlConnection conn = DataAccess.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Users";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new UserDTO()
                    {
                        UserID   = reader["UserID"] != DBNull.Value ? (int)reader["UserID"] : 0,
                        UserName = reader["UserName"].ToString(),
                        FullName = reader["FullName"] != DBNull.Value ? reader["FullName"].ToString() : "",
                        Password = reader["Password"].ToString(),
                        Phone    = reader["Phone"] != DBNull.Value ? reader["Phone"].ToString() : "",
                        Role     = reader["Role"] != DBNull.Value ? reader["Role"].ToString() : ""
                    });
                }
            }
            return list;
        }
        public bool InsertUser(UserDTO user)
        {
            using (SqlConnection conn = DataAccess.GetConnection())
            {
                conn.Open();

                string query = "INSERT INTO Users(UserName, FullName, Password, Phone, Role) VALUES(@u,@fn,@p,@ph,@r)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@u", user.UserName);
                    cmd.Parameters.AddWithValue("@fn", string.IsNullOrEmpty(user.FullName) ? "" : user.FullName);
                    cmd.Parameters.AddWithValue("@p", user.Password);
                    cmd.Parameters.AddWithValue("@ph", string.IsNullOrEmpty(user.Phone) ? "" : user.Phone);
                    cmd.Parameters.AddWithValue("@r", user.Role);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public bool CheckExist(string username)
        {
            using (SqlConnection conn = DataAccess.GetConnection())
            {
                conn.Open();

                string query = "SELECT COUNT(*) FROM Users WHERE UserName=@u";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@u", username);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        public bool UpdateUser(UserDTO user)
        {
            using (SqlConnection conn = DataAccess.GetConnection())
            {
                conn.Open();

                string query = "UPDATE Users SET FullName=@fn, Password=@p, Phone=@ph, Role=@r WHERE UserName=@u";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@u", user.UserName);
                cmd.Parameters.AddWithValue("@fn", string.IsNullOrEmpty(user.FullName) ? "" : user.FullName);
                cmd.Parameters.AddWithValue("@p", user.Password);
                cmd.Parameters.AddWithValue("@ph", string.IsNullOrEmpty(user.Phone) ? "" : user.Phone);
                cmd.Parameters.AddWithValue("@r", user.Role);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }  
}
