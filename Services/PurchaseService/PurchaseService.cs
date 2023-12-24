using IMSSPM.Data;

namespace IMSSPM.Services.PurchaseService
{
    public class PurchaseService : IPurchaseService
    {
        private readonly DataContext _DBAccess;
        public PurchaseService(DataContext context)
        {
            _DBAccess = context;
        }
        public async Task<Purchase> AddPurchase(Purchase purchase)
        {
            _DBAccess.Purchases.Add(purchase);
            await _DBAccess.SaveChangesAsync();

            return purchase;
        }

        public async Task<Purchase?> DeletePurchase(int id)
        {
            var result = await _DBAccess.Purchases.FindAsync(id);
            if (result == null)
                return null;
    
            _DBAccess.Purchases.Remove(result);
            await _DBAccess.SaveChangesAsync();
            return result;
        }

        public async Task<Purchase?> GetPurchase(int id)
        {
            var result = await _DBAccess.Purchases.FindAsync(id);
            if (result == null)
                return null;

            return result;
        }

        public async Task<List<Purchase>> GetPurchases()
        {
            return await _DBAccess.Purchases.ToListAsync();
        }

        public async Task<Purchase?> UpdatePurchase(Purchase purchase)
        {
            var result = await _DBAccess.Purchases.FindAsync(purchase.OrderID);
            if (result == null)
                return null;

            result.ProductID = purchase.ProductID;
            result.OrderDate = DateTime.Now;
            result.QuantityOrdered = purchase.QuantityOrdered;
            result.PurchaseAmount = purchase.PurchaseAmount;

            await _DBAccess.SaveChangesAsync();

            return await _DBAccess.Purchases.FindAsync(purchase.OrderID);
        }
    }
}