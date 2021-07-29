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
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace RookieShop.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductsController(ApplicationDbContext context, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var productList = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(productList);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(string id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return _mapper.Map<ProductDto>(product);
        }

        [HttpGet("Details/{id}")]
        public ActionResult<ProductDto> GetProductWithRating(string id)
        {
            var product = _context.Products.Single(p => p.id == id);

            return _mapper.Map<ProductDto>(product);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> PutProduct(string id, [FromForm] ProductDto productDto)
        {
            if (id != productDto.id)
            {
                return BadRequest();
            }

            //Product product = _mapper.Map<Product>(productDto);
            Product old = _context.Products.Single(p => p.id == id);

            if (productDto.image != null)
			{
                string uniqueFileName = UploadedFile(productDto);
                old.imageUri = uniqueFileName;
            }
            old.name = productDto.name ?? old.name;
            old.description = productDto.description ?? old.description;
            old.amount = productDto.amount;
            old.price = productDto.price;
            old.categoryid = productDto.categoryid ?? old.categoryid;

            old.modifyDate = DateTime.Now;


            _context.Entry(old).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<Product>> PostProduct([FromForm] ProductDto productDto)
        {
            Product product = _mapper.Map<Product>(productDto);

            string uniqueFileName = UploadedFile(productDto);
            product.imageUri = uniqueFileName;

            product.createDate = DateTime.Now;
            product.modifyDate = DateTime.Now;

            product.isDeleted = false;

            _context.Products.Add(product);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductExists(product.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProduct", new { id = product.id }, product);
        }


        private string UploadedImage(IFormFile image)
        {
            string uniqueFileName = null;

            if (image != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "ProductImage");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

		private string UploadedFile(ProductDto model)
		{
			string uniqueFileName = null;

			if (model.image != null)
			{
				string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "ProductImage");
				uniqueFileName = Guid.NewGuid().ToString() + "_" + model.image.FileName;

				string filePath = Path.Combine(uploadsFolder, uniqueFileName);
				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					model.image.CopyTo(fileStream);
				}
			}
			return uniqueFileName;
		}

        /*public async Task DeleteFileAsync(string fileName)
        {
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "ProductImage");

            var filePath = Path.Combine(uploadsFolder, fileName);
            if (System.IO.File.Exists(filePath))
            {
                await Task.Run(() => System.IO.File.Delete(filePath));
            }
        }*/

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            product.isDeleted = true;
            //_context.Products.Remove(product);
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(string id)
        {
            return _context.Products.Any(e => e.id == id);
        }
    }
}
