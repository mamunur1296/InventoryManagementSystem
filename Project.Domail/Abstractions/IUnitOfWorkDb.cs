using Project.Domail.Abstractions.CommandRepositories;
using Project.Domail.Abstractions.QueryRepositories;

namespace Project.Domail.Abstractions
{
    public interface IUnitOfWorkDb
    {
        IProductSizeCommandRepository productSizeCommandRepository { get; }
        IProductSizeQueryRepository productSizeQueryRepository { get; }
        IRetailerCommandRepository retailerCommandRepository { get; }
        IRetailerQueryRepository retailerQueryRepository { get; }
        ICompanyCommandRepository companyCommandRepository { get; }
        ICompanyrQueryRepository companyrQueryRepository { get; }
        IDeliveryAddressQueryRepository deliveryAddressQueryRepository { get; }
        IDeliveryAddressCommandRepository deliveryAddressCommandRepository { get; }
        IOrderCommandRepository orderCommandRepository { get; }
        IOrderQueryRepository orderQueryRepository { get; }
        IProdReturnCommandRepository prodReturnCommandRepository { get; }   
        IProdReturnQueryRepository prodReturnQueryRepository { get; }
        IProductCommandRepository productCommandRepository { get; }
        IProductQueryRepository productQueryRepository { get; }
        IStockCommandRepository stockCommandRepository { get; }
        IStockQueryRepository stockQueryRepository { get; } 
        ITraderCommandRepository traderCommandRepository { get; }
        ITraderQueryRepository traderQueryRepository { get; }
        IUserCommandRepository userCommandRepository { get; }
        IUserQueryRepository userQueryRepository { get; }
        IValveCommandRepository valveCommandRepository { get; }
        IValverQueryRepository valverQueryRepository { get; }
        Task SaveAsync();
    }
}
