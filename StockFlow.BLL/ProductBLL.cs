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

        public bool Add(ProductDTO p)
        {
            if (p == null || string.IsNullOrWhiteSpace(p.Name)) return false;
            return productDAL.InsertProduct(p);
        }

        public bool Update(ProductDTO p)
        {
            if (p == null || p.ProductID <= 0) return false;
            return productDAL.UpdateProduct(p);
        }

        public bool Delete(int id) => productDAL.DeleteProduct(id);
    }
}