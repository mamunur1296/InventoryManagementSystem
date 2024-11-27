using Project.Application.DTOs;
using Project.Domail.Entities;


namespace Project.Application.Interfaces
{
    public interface IPurchaseServices
    {
        public Task<(bool, string id)> PurchaseProduct(PurchaseItemDTOs entitys);
        public Task<Purchase> PurchaseDetail(string id);
    }
}
