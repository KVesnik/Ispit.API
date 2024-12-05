using Ispit.API.Data;
using Ispit.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Ispit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingItemsController : ControllerBase
    {
        public readonly ApplicationDbContext _context;

        public ShoppingItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingItem>>> GetShoppingItems()
        {
            return await _context.ShoppingItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingItem>>GetShoppingItems(int id)
        {
            var shoppingItem = await _context.ShoppingItems.FindAsync(id);

            return shoppingItem;

        }

        [HttpPost]
        public async Task<ActionResult<ShoppingItem>>PostShoppingItem(ShoppingItem shoppingItem)
        {
            shoppingItem.Id = 0;
            _context.ShoppingItems.Add(shoppingItem);

            await _context.SaveChangesAsync();

            var resourceUrl = Url.Action(nameof(GetShoppingItems), new { id = shoppingItem.Id });
            return Created(resourceUrl, shoppingItem);
        }

        [HttpPut]
        public async Task<IActionResult>PutShoppingItem(int id, [FromBody]ShoppingItem shoppingItem)
        {
            _context.Entry(shoppingItem).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult>DeleteShoppingItem(int id)
        {
            var shoppingItem = await _context.ShoppingItems.FindAsync(id);

            _context.ShoppingItems.Remove(shoppingItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
