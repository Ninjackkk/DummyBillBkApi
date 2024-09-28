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

        [HttpGet]
        [Route("GetAllCategories")]
        public IActionResult GetAllCategories()
        {
            var data = db.Categories.ToList();                         // Fetch using api
            return Ok(data);
        }

        [HttpGet]
        [Route("GetItemsByCategoryId/{categoryId}")]
        public IActionResult GetItemsByCategoryId(int categoryId)
        {
            var items = db.Inventories.Where(c => c.CategoryID == categoryId).ToList();
            return Ok(items);
        }
    }
}
