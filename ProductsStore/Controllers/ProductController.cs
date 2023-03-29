using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsStore.Models.dbContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            using (HardCodeContext db = new HardCodeContext())
            {
                List<Product> products =  await db.Products.ToListAsync();

                if (products.Count == 0)
                {
                    return NotFound();
                }

                return Ok(products);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            using (HardCodeContext db = new HardCodeContext())
            {
                Product product = await db.Products.FindAsync(id);

                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
        }
    }
}
