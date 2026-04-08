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
                        ProductID   = (int)reader["ProductID"],
                        Name        = reader["Name"].ToString(),
                        Quantity    = (int)reader["Quantity"],
                        Description = reader["Description"].ToString(),
                        CategoryID  = (int)reader["CategoryID"]
                    };
                    list.Add(Po);
                }
            }
            return list;
        }

        public bool InsertProduct(ProductDTO p)
        {
            using (SqlConnection conn = DataAccess.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Products(Name, Quantity, Description, CategoryID) VALUES(@n,@qty,@desc,@cid)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@n",    p.Name);
                cmd.Parameters.AddWithValue("@qty",  p.Quantity);
                cmd.Parameters.AddWithValue("@desc", p.Description ?? "");
                cmd.Parameters.AddWithValue("@cid",  p.CategoryID);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateProduct(ProductDTO p)
        {
            using (SqlConnection conn = DataAccess.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Products SET Name=@n, Quantity=@qty, Description=@desc, CategoryID=@cid WHERE ProductID=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@n",    p.Name);
                cmd.Parameters.AddWithValue("@qty",  p.Quantity);
                cmd.Parameters.AddWithValue("@desc", p.Description ?? "");
                cmd.Parameters.AddWithValue("@cid",  p.CategoryID);
                cmd.Parameters.AddWithValue("@id",   p.ProductID);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteProduct(int id)
        {
            using (SqlConnection conn = DataAccess.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Products WHERE ProductID=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
