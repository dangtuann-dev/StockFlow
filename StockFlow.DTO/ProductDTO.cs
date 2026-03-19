using System;
using System.Collections.Generic;
using System.Text;

namespace StockFlow.DTO
{
    public class ProductDTO
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }

        // Khóa ngoại liên kết với bảng CATEGORIES
        public int CategoryID { get; set; }
    }
}
