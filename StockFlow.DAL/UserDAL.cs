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
        DBConnect db = new DBConnect();

        public UserDTO? Login(string username, string password)
        {
            SqlConnection conn = db.GetConnection();
            conn.Open();

            string query = "SELECT * FROM Users WHERE UserName=@u AND Password=@p";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@u", username);
            cmd.Parameters.AddWithValue("@p", password);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                UserDTO user = new UserDTO()
                {
                    UserName = reader["UserName"].ToString(),
                    Role = reader["Role"].ToString()
                };

                conn.Close();
                return user;
            }

            conn.Close();
            return null;
        }
        public bool InsertUser(UserDTO user)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = "INSERT INTO Users(UserName, Password, Role) VALUES(@u,@p,@r)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@u", user.UserName);
                    cmd.Parameters.AddWithValue("@p", user.Password);
                    cmd.Parameters.AddWithValue("@r", user.Role);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public bool CheckExist(string username)
        {
            using (SqlConnection conn = db.GetConnection())
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
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = "UPDATE Users SET Password=@p, Role=@r WHERE UserName=@u";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@u", user.UserName);
                cmd.Parameters.AddWithValue("@p", user.Password);
                cmd.Parameters.AddWithValue("@r", user.Role);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }  
}
