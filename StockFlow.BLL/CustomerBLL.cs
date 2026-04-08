using StockFlow.DAL;
using StockFlow.DTO;
using System.Collections.Generic;

namespace StockFlow.BLL
{
    public class CustomerBLL
    {
        CustomerDAL dal = new CustomerDAL();

        public List<CustomerDTO> GetAllCustomers() => dal.GetAllCustomers();

        public bool Add(CustomerDTO c)
        {
            if (c == null || string.IsNullOrWhiteSpace(c.Name)) return false;
            return dal.InsertCustomer(c);
        }

        public bool Update(CustomerDTO c)
        {
            if (c == null || c.CustomerID <= 0) return false;
            return dal.UpdateCustomer(c);
        }

        public bool Delete(int id) => dal.DeleteCustomer(id);
    }
}
