using Project.Domail.Abstractions.CommandRepositories;
using Project.Domail.Entities;
using Project.Infrastructure.DataContext;
using Project.Infrastructure.Implementation.Command.Base;

namespace Project.Infrastructure.Implementation.Command
{
    public class OrderCommandRepository : CommandRepository<Order>, IOrderCommandRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public OrderCommandRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        // Implement additional methods specific to OrderCommandRepository here
    }
}
