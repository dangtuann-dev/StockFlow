using StockFlow.DAL;
using StockFlow.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockFlow.BLL
{
    public class ProductBLL
    {
        private ProductDAL productDAL = new ProductDAL();

        public List<ProductDTO> GetListProduct()
        {
            return productDAL.GetAllProducts();
        }
    }
}