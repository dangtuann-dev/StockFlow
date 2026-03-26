using System;
using System.Collections.Generic;
using System.Text;

namespace StockFlow.DTO
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string DisplayPassword => new string('*', Password?.Length ?? 0);
        public string Phone { get; set; }
    }
}
