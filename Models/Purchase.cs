using System.ComponentModel.DataAnnotations;

namespace IMSSPM.Models
{
    public class Purchase
    {
        [Key]
        public int OrderID { get; set; } 
        public int ProductID { get; set; }
        public DateTime OrderDate { get; set; }
        public int QuantityOrdered { get; set; }
        public int PurchaseAmount { get; set; }
    }
}
