using BillBookApi.Data;
using BillBookApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
           //Creating PurchaseOrder in PurchaseOrders table
            db.PurchaseOrders.Add(purchaseRequest.PurchaseOrder);
            db.SaveChanges();
            //Inserting Stocks in MyStocks table with PurchaseOrderId
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

        //Getting categories for Categories Dropdown

        [HttpGet]
        [Route("GetAllCategories")]
        public IActionResult GetAllCategories()
        {
            var data = db.Categories.ToList();                         
            return Ok(data);
        }

       // Getting Items From Global Inventory as per selected category

        [HttpGet]
        [Route("GetItemsByCategoryId/{categoryId}")]
        public IActionResult GetItemsByCategoryId(int categoryId)
        {
            var items = db.Inventories.Where(c => c.CategoryID == categoryId).ToList();
            return Ok(items);
        }



        //Getting parties for party dropdwon
        [HttpGet]
        [Route("GetAllParties")]
        public IActionResult GetAllParties()
        {
           var parties= db.Parties.ToList();
           return Ok(parties);
        }

        //Api working , fetching at consuming side is remaining

        [HttpGet]
        [Route("GetPartyStocksByBusinessId/{businessId}/{purchaseOrderId}")]
        public IActionResult GetPartyStocksByBusinessId(int businessId, int purchaseOrderId)
        {
            var mystock = db.MyStocks.FromSqlRaw("EXEC GetMyStocks @BusinessId = {0}, @PurchaseOrderId = {1}", businessId, purchaseOrderId).ToList();
            return Ok(mystock);
        }


    }
}
