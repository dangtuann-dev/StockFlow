using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using StockFlow.DTO;

namespace StockFlow.DAL
{
    public class ProductDAL
    {
        public List<ProductDTO> GetAllProducts()
        {
            List<ProductDTO> list = new List<ProductDTO>();
            using (SqlConnection conn = DataAccess.GetConnection())
            {
                string query = "SELECT * FROM Products"; 
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProductDTO Po = new ProductDTO
                    {
                        ProductID = (int)reader["ProductID"],
                        Name = reader["Name"].ToString(),
                        Quantity = (int)reader["Quantity"],
                        Description = reader["Description"].ToString(),
                        CategoryID = (int)reader["CategoryID"]
                    };
                    list.Add(Po);
                }
            }
            return list;
        }
    }
}
