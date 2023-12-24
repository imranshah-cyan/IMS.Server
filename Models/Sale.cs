using System.ComponentModel.DataAnnotations;

namespace IMSSPM.Models
{
    public class Sale
    {
        [Key]
        public int TransactionID { get; set; }
        public int ProductID { get; set; }
        public DateTime TransactionDate { get; set; }
        public int QuantitySold { get; set; }
        public int SaleAmount { get; set; }
    }
}
