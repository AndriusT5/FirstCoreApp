using CoreApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Data
{
    public class MyAppRepository : IMyAppRepository
    {
        private readonly MyAppContext _context;
        private readonly ILogger<MyAppContext> _logger;

        public MyAppRepository(MyAppContext context,ILogger<MyAppContext> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void AddEntity(object model)
        {
            _context.Add(model);
        }

        public IEnumerable<Order> GetAllOrders(bool includeItems)
        {
            if (includeItems)
            {
                return _context.Orders.Include(o => o.Items).ThenInclude(i => i.Product).ToList();
            }
            else
            {
                return _context.Orders.ToList();
            }
        }

        public IEnumerable<Order> GetAllOrdersByUser(string username, bool includeItems)
        {
            if (includeItems)
            {
                return _context.Orders.Where(u => u.User.UserName == username).Include(o => o.Items).ThenInclude(i => i.Product).ToList();
            }
            else
            {
                return _context.Orders.Where(u => u.User.UserName == username).ToList();
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                _logger.LogInformation("Get All Product was launched..");
                return _context.Products.OrderBy(t => t.Title).ToList();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Failed to get all products {ex}");
                return null;
            }
        }

        public Order GetOrderById(int id)
        {
            return _context.Orders.Include(o => o.Items).ThenInclude(i => i.Product).Where(o => o.Id == id).FirstOrDefault();
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return _context.Products.Where(c => c.Category.Equals(category)).ToList();
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
