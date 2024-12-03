using Microsoft.EntityFrameworkCore;
using Project.Domail.Abstractions.QueryRepositories;
using Project.Domail.Entities;
using Project.Infrastructure.DataContext;
using Project.Infrastructure.Implementation.Query.Base;

namespace Project.Infrastructure.Implementation.Query
{
    public class OrderQueryRepository : QueryRepository<Order>, IOrderQueryRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public OrderQueryRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Order> GetOrderReportById(Guid id)
        {
            // Ensure you include OrderDetails in the query
            var order = await _applicationDbContext.Orders
                .Include(o => o.PurchaseDetails)
                .ThenInclude(od=>od.Product)
                .FirstOrDefaultAsync(o => o.Id == id);

            // If no order is found, you can return null or handle it appropriately
            if (order == null)
            {
                throw new Exception("Order not found.");
            }

            return order;
        }
        // Implement additional methods specific to OrderQueryRepository here
    }
}
