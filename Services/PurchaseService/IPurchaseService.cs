namespace IMSSPM.Services.PurchaseService
{
    public interface IPurchaseService
    {
        Task<List<Purchase>> GetPurchases();
        Task<Purchase?> GetPurchase(int id);
        Task<Purchase> AddPurchase(Purchase purchase);
        Task<Purchase?> UpdatePurchase(Purchase purchase);
        Task<Purchase?> DeletePurchase(int id);
    }
}