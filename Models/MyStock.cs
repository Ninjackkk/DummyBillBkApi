using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace BillBookApi.Models
{
    public class MyStock
    {
        [Key]
        public int StockId { get; set; }  // no use for this
        public int PurchaseOrderId { get; set; }
        public string? ItemName { get; set; }
        public double? ItemCode { get; set; }
        public double? ItemHSNCode { get; set; }
        public string? Category { get; set; }
        public double? Quantity { get; set; }
    }
}
