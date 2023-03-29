using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsStore.Models.dbContext;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult Categories()
        {
            using (HardCodeContext context = new HardCodeContext())
            {
                List<Category> categoryList = context.Categories.ToList();

                if (categoryList.Count == 0)
                {
                    NotFound();
                }

                return Ok(categoryList);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            using (HardCodeContext db = new HardCodeContext())
            {
                var category = db.Categories.Find(id);
                if (category == null)
                {
                    return NotFound();
                }

                db.Categories.Remove(category);
                await db.SaveChangesAsync();

                return Ok();
            }
        }
    }
}
