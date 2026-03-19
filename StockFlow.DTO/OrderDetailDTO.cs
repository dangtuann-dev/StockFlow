using System;
using System.Collections.Generic;
using System.Text;

namespace StockFlow.DTO
{
    public class OrderDetailDTO
    {
        public int OrderDetailID { get; set; }

        // Khóa ngoại liên kết với bảng ORDERS
        public int OrderID { get; set; }

        // Khóa ngoại liên kết với bảng PRODUCTS
        public int ProductID { get; set; }
        public int Qty { get; set; }
        public decimal Total { get; set; }
    }
}
