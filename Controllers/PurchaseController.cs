using BillBookApi.Data;
using BillBookApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BillBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public PurchaseController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        [Route("NewPurchase")]
        public IActionResult NewPurchase([FromBody] PurchaseRequest purchaseRequest)
        {
            // Add the purchase order to the context
            db.PurchaseOrders.Add(purchaseRequest.PurchaseOrder);

            // Save changes to get the PurchaseOrderId generated
            db.SaveChanges();

            // Now that the PurchaseOrderId is generated, set it for each stock item
            foreach (var stock in purchaseRequest.Stocks)
            {
                stock.PurchaseOrderId = purchaseRequest.PurchaseOrder.PurchaseOrderId;
            }

            // Add stocks using AddRange
            db.MyStocks.AddRange(purchaseRequest.Stocks);

            // Save changes to the database again to save stocks
            db.SaveChanges();

            return Ok();

        }






    }
}
