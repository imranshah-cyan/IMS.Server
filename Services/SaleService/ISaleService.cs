namespace IMSSPM.Services.SaleService
{
    public interface ISaleService
    {
        Task<List<Sale>> GetSales();
        Task<Sale?> GetSale(int id);
        Task<Sale> AddSale(Sale sale);
        Task<Sale?> UpdateSale(Sale sale);
        Task<Sale?> DeleteSale(int id);
    }
}
