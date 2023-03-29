using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProductsStore.Models.dbContext;
using ProductsStore.Models.MainModels;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
                    return NotFound();
                }

                return Ok(categoryList);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            using (HardCodeContext db = new HardCodeContext())
            {
                var category = await db.Categories.FindAsync(id);
                if (category == null)
                {
                    return BadRequest();
                }

                db.Categories.Remove(category);
                await db.SaveChangesAsync();

                return Ok();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryModel category)
        {
            if (category == null || string.IsNullOrEmpty(category.Name))
            {
                return BadRequest("The input parameter cannot be empty");
            }

            using (HardCodeContext db = new HardCodeContext())
            {
                Category newCategory = new Category()
                {
                    Products = null,
                    Name = category.Name,
                };

                await db.Categories.AddAsync(newCategory);
                await db.SaveChangesAsync();
                return Ok();
            }
        }
    }
}
