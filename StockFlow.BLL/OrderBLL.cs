using StockFlow.DAL;
using StockFlow.DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace StockFlow.BLL
{
    public class OrderBLL
    {
        OrderDAL dal = new OrderDAL();

        public DataTable GetOrdersView() => dal.GetOrdersView();

        public List<OrderDTO> GetAllOrders() => dal.GetAllOrders();

        /// <summary>Tạo đơn hàng + chi tiết, trả về OrderID hoặc -1 nếu thất bại.</summary>
        public int PlaceOrder(int customerId, int productId, int qty, decimal total)
        {
            if (customerId <= 0 || productId <= 0 || qty <= 0) return -1;

            OrderDTO order = new OrderDTO
            {
                CustomerID = customerId,
                OrderDate  = DateTime.Now
            };

            int orderId = dal.InsertOrder(order);
            if (orderId <= 0) return -1;

            OrderDetailDTO detail = new OrderDetailDTO
            {
                OrderID   = orderId,
                ProductID = productId,
                Qty       = qty,
                Total     = total
            };

            return dal.InsertOrderDetail(detail) ? orderId : -1;
        }

        public bool UpdateDetail(OrderDetailDTO detail) => dal.UpdateOrderDetail(detail);

        public bool DeleteOrder(int orderId) => dal.DeleteOrder(orderId);
    }
}
