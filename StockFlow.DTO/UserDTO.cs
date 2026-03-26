using System;
using System.Collections.Generic;
using System.Text;

namespace StockFlow.DTO
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
