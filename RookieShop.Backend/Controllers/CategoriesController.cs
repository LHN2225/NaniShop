using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RookieShop.Backend.Data;
using RookieShop.Backend.Models;
using RookieShop.Shared;
using AutoMapper;

namespace RookieShop.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CategoriesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            var categoryList = await _context.Categories.ToListAsync();
            return _mapper.Map<List<CategoryDto>>(categoryList);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public ActionResult<CategoryDto> GetCategory(string id)
        {
            var category = _context.Categories.Single(c => c.id == id);

            if (category == null)
			{
				return NotFound();
			}

            CategoryDto categoryDto = _mapper.Map<CategoryDto>(category);

			return categoryDto;
        }

        // GET: api/Categories/Details/5
        [HttpGet("Details/{id}")]
        public ActionResult<List<ProductDto>> GetProductByCategoryId(string id)
		{
            var productList = _context.Products.Where(p => p.categoryid == id).ToList();
            List<ProductDto> productListDto = _mapper.Map<List<ProductDto>>(productList);
            return productListDto;
		}

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(string id, CategoryDto categoryDto)
        {
            Category category = _mapper.Map<Category>(categoryDto);

            if (id != category.id)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(CategoryDto categoryDto)
        {
            Category category = _mapper.Map<Category>(categoryDto);

            string newId = "RSCA000";

            int recordCount = _context.Categories.Count();

            recordCount++;
            string tmp = newId;
            while (CategoryExists(tmp + recordCount.ToString())) ++recordCount;
            newId += recordCount.ToString();

            category.id = newId;
            category.isDeleted = false;

            _context.Categories.Add(category);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CategoryExists(category.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCategory", new { id = category.id }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            category.isDeleted = true;
            _context.Entry(category).State = EntityState.Modified;

            //_context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryExists(string id)
        {
            return _context.Categories.Any(e => e.id == id);
        }
    }
}
