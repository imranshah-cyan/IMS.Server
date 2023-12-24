
using IMSSPM.Data;
using IMSSPM.Models;

namespace IMSSPM.Services.SaleService
{
    public class SaleService : ISaleService
    {
        private readonly DataContext _DBAccess;
        public SaleService(DataContext context)
        {
            _DBAccess = context;
        }
        public async Task<Sale> AddSale(Sale sale)
        {
            _DBAccess.Sales.Add(sale);
            await _DBAccess.SaveChangesAsync();

            return sale;
        }

        public async Task<Sale?> DeleteSale(int id)
        {
            var result = await _DBAccess.Sales.FindAsync(id);
            if (result == null)
                return null;

            _DBAccess.Sales.Remove(result);
            await _DBAccess.SaveChangesAsync();
            return result;
        }

        public async Task<Sale?> GetSale(int id)
        {
            var result = await _DBAccess.Sales.FindAsync(id);
            if (result == null)
                return null;

            return result;
        }

        public async Task<List<Sale>> GetSales()
        {
            return await _DBAccess.Sales.ToListAsync();
        }

        public async Task<Sale?> UpdateSale(Sale sale)
        {
            var result = await _DBAccess.Sales.FindAsync(sale.TransactionID);
            if (result == null)
                return null;

            result.ProductID = sale.ProductID;
            result.TransactionDate = DateTime.Now;
            result.QuantitySold = sale.QuantitySold;
            result.SaleAmount = sale.SaleAmount;

            await _DBAccess.SaveChangesAsync();

            return await _DBAccess.Sales.FindAsync(sale.TransactionID);
        }
    }
}
