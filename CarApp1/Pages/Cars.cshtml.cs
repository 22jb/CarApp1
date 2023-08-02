using CarApp1.Pages.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarApp1.Pages
{
    public class CarsModel : PageModel
    {
        private readonly CarsDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public List<Car> Cars { get; set; } = new List<Car>();

        [BindProperty]
        public Car newCar { get; set; }

        [BindProperty]
        public IFormFile CarImage { get; set; }

        public CarsModel(CarsDbContext context, IWebHostEnvironment webHostEnvironment )
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public void OnGet()
        {
            
            if (!_context.Cars.Any())
            {
                _context.SeedData();
            }
            Cars = _context.Cars.ToList();

        }

        public IActionResult OnPost()
        {
            if (CarImage != null && CarImage.Length > 0)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                string uniqueFileName = Path.GetRandomFileName() + "_" + CarImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    CarImage.CopyTo(fileStream);
                }

                newCar.ImagePath = "/uploads/" + uniqueFileName;
            }

            _context.Cars.Add(newCar);
            _context.SaveChanges();
            return RedirectToPage();
        }
    }
}
