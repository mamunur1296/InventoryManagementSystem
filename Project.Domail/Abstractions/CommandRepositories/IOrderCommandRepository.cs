using Project.Domail.Abstractions.CommandRepositories.Base;
using Project.Domail.Entities;

namespace Project.Domail.Abstractions.CommandRepositories
{
    public interface IOrderCommandRepository : ICommandRepository<Order>
    {
        // Add specific command methods here if needed
    }
}
