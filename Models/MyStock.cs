﻿using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace BillBookApi.Models
{
    public class MyStock
    {
        [Key]
        public int StockId { get; set; }  // no use for this
        public int PurchaseOrderId { get; set; }
        public string? ItemName { get; set; }
        public string? ItemCode { get; set; }
        public string? HSNCode { get; set; }
        public string? Category { get; set; }
        public double? Quantity { get; set; }
    }
}
