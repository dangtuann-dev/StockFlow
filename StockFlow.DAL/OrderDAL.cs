using StockFlow.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace StockFlow.DAL
{
    public class OrderDAL
    {
        // ───── ORDER ─────

        public List<OrderDTO> GetAllOrders()
        {
            var list = new List<OrderDTO>();
            using (SqlConnection conn = DataAccess.GetConnection())
            {
                conn.Open();
                string query = "SELECT OrderID, CustomerID, OrderDate FROM Orders";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new OrderDTO
                    {
                        OrderID    = (int)reader["OrderID"],
                        CustomerID = (int)reader["CustomerID"],
                        OrderDate  = (DateTime)reader["OrderDate"]
                    });
                }
            }
            return list;
        }

        /// <summary>Thêm Order mới, trả về OrderID mới tạo.</summary>
        public int InsertOrder(OrderDTO order)
        {
            using (SqlConnection conn = DataAccess.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Orders(CustomerID, OrderDate) VALUES(@cid, @date); SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cid",  order.CustomerID);
                cmd.Parameters.AddWithValue("@date", order.OrderDate);
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }

        public bool DeleteOrder(int orderId)
        {
            using (SqlConnection conn = DataAccess.GetConnection())
            {
                conn.Open();
                // Xóa chi tiết trước
                string delDetail = "DELETE FROM ORDER_DETAILS WHERE OrderID=@id";
                new SqlCommand(delDetail, conn) { Parameters = { new SqlParameter("@id", orderId) } }.ExecuteNonQuery();
                // Xóa order
                string delOrder = "DELETE FROM Orders WHERE OrderID=@id";
                SqlCommand cmd = new SqlCommand(delOrder, conn);
                cmd.Parameters.AddWithValue("@id", orderId);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ───── ORDER DETAIL ─────

        public List<OrderDetailDTO> GetOrderDetails(int orderId)
        {
            var list = new List<OrderDetailDTO>();
            using (SqlConnection conn = DataAccess.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM ORDER_DETAILS WHERE OrderID=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", orderId);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new OrderDetailDTO
                    {
                        OrderDetailID = (int)reader["OrderDetailID"],
                        OrderID       = (int)reader["OrderID"],
                        ProductID     = (int)reader["ProductID"],
                        Qty           = (int)reader["Qty"],
                        Total         = (decimal)reader["Total"]
                    });
                }
            }
            return list;
        }

        /// <summary>Thêm chi tiết đơn hàng.</summary>
        public bool InsertOrderDetail(OrderDetailDTO detail)
        {
            using (SqlConnection conn = DataAccess.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO ORDER_DETAILS(OrderID, ProductID, Qty, Total) VALUES(@oid,@pid,@qty,@total)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@oid",   detail.OrderID);
                cmd.Parameters.AddWithValue("@pid",   detail.ProductID);
                cmd.Parameters.AddWithValue("@qty",   detail.Qty);
                cmd.Parameters.AddWithValue("@total", detail.Total);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateOrderDetail(OrderDetailDTO detail)
        {
            using (SqlConnection conn = DataAccess.GetConnection())
            {
                conn.Open();
                string query = "UPDATE ORDER_DETAILS SET Qty=@qty, Total=@total WHERE OrderDetailID=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@qty",   detail.Qty);
                cmd.Parameters.AddWithValue("@total", detail.Total);
                cmd.Parameters.AddWithValue("@id",    detail.OrderDetailID);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ───── JOIN VIEW (dùng cho DataGridView tổng hợp) ─────

        public DataTable GetOrdersView()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DataAccess.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT o.OrderID,
                           c.CustomerID, c.Name AS CustomerName,
                           p.ProductID,  p.Name AS ProductName,
                           od.Qty, od.Total, o.OrderDate
                    FROM Orders o
                    JOIN Customers c ON o.CustomerID = c.CustomerID
                    JOIN ORDER_DETAILS od ON o.OrderID = od.OrderID
                    JOIN Products p ON od.ProductID = p.ProductID";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
