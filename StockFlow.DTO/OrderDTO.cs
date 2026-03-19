using System;
using System.Collections.Generic;
using System.Text;

namespace StockFlow.DTO
{
    public class OrderDTO
    {
        public int OrderID { get; set; }

        // Khóa ngoại liên kết với bảng CUSTOMERS
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
