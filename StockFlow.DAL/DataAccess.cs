using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockFlow.DAL
{
    public static class DataAccess
    {
        // Thay địa chỉ SQL để sử dụng (lưu ý xóa Trust Server Certificate=True)
        public static string ConnectionString = @"Data Source=ADMIN-PC;Initial Catalog=StockFlowDb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

    }
}
