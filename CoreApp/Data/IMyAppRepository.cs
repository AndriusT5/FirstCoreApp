using System.Collections.Generic;
using CoreApp.Data.Entities;

namespace CoreApp.Data
{
    public interface IMyAppRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
       
        IEnumerable<Order> GetAllOrders(bool includeItems);
        IEnumerable<Order> GetAllOrdersByUser(string username, bool includeItems);
        Order GetOrderById(int id);

        bool SaveAll();
        void AddEntity(object model);
       
    }
}