using StockFlow.DTO;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace StockFlow.DAL
{
    public class CustomerDAL
    {
        public List<CustomerDTO> GetAllCustomers()
        {
            var list = new List<CustomerDTO>();
            using (SqlConnection conn = DataAccess.GetConnection())
            {
                conn.Open();
                string query = "SELECT CustomerID, Name FROM Customers";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new CustomerDTO
                    {
                        CustomerID = (int)reader["CustomerID"],
                        Name = reader["Name"].ToString()
                    });
                }
            }
            return list;
        }

        public bool InsertCustomer(CustomerDTO c)
        {
            using (SqlConnection conn = DataAccess.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Customers(Name) VALUES(@n)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@n", c.Name);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateCustomer(CustomerDTO c)
        {
            using (SqlConnection conn = DataAccess.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Customers SET Name=@n WHERE CustomerID=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@n", c.Name);
                cmd.Parameters.AddWithValue("@id", c.CustomerID);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteCustomer(int id)
        {
            using (SqlConnection conn = DataAccess.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Customers WHERE CustomerID=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
