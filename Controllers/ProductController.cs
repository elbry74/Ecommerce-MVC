using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;

namespace Ecommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, IFormFile imageFile)
        {
            UploadImage(product, imageFile);
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Products.Add(product);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while saving the product.");
                    Console.WriteLine(ex.Message);
                }
            }

            return View(product);
        }


       private void UploadImage(Product product, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                string imageFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", imageFileName);

                // Ensure the "Images" directory exists
                string imagesDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                if (!Directory.Exists(imagesDirectory))
                {
                    Directory.CreateDirectory(imagesDirectory);
                }

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                product.ImageUrl = "Images/" + imageFileName;
            }
            else if (product.Id == 0 && string.IsNullOrWhiteSpace(product.ImageUrl))
            {
                // If no image is provided and it's a new product, set a default image
                product.ImageUrl = "Images/DefaultImage.jpg";
            }
            // If an image URL is provided or it's an existing product, leave it as is
        }


    }
}
