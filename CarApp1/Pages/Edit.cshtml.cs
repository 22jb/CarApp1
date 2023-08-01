using CarApp1.Pages.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarApp1.Pages
{
    public class EditModel : PageModel
    {
        private readonly CarsDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        //public Car? car { get; set; } = new Car();
        [BindProperty]
        public EditCarModel EditCarModel { get; set; }

        [BindProperty]
        public IFormFile CarImage { get; set; }

        public EditModel(CarsDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        //public Guid Id { get; private set; }

        public void OnGet(Guid id)
        {
            var car_entry = _context.Cars.Find(id);
            if (car_entry != null)
            {
                EditCarModel = new EditCarModel()
                {
                    Id = car_entry.Id,
                    Brand = car_entry.Brand,
                    Model = car_entry.Model,
                    Colour = car_entry.Colour,
                    EngineType = car_entry.EngineType,
                    EngineSize = car_entry.EngineSize,
                    ImagePath = car_entry.ImagePath
                };
            }
        }

        public IActionResult OnPost()
        {
            if(EditCarModel != null)
            {
                var car_entry = _context.Cars.Find(EditCarModel.Id);

                if (car_entry != null)
                {

                    car_entry.Id = EditCarModel.Id;
                    car_entry.Brand = EditCarModel.Brand;
                    car_entry.Model = EditCarModel.Model;
                    car_entry.Colour = EditCarModel.Colour;
                    car_entry.EngineType = EditCarModel.EngineType;
                    car_entry.EngineSize = EditCarModel.EngineSize;
                    if (CarImage != null && CarImage.Length > 0)
                    {
                        Console.WriteLine("True");
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                        string uniqueFileName = Path.GetRandomFileName() + "_" + CarImage.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            CarImage.CopyTo(fileStream);
                        }

                        car_entry.ImagePath = "/uploads/" + uniqueFileName;
                    }
                    else
                    {
                        car_entry.ImagePath = EditCarModel.ImagePath;
                    }
                    
                    _context.SaveChanges();
                    
                }
            }
            return RedirectToPage("/Cars");
        }

        public IActionResult OnPostDelete()
        {
            var car_entry = _context.Cars.Find(EditCarModel.Id);
            if (car_entry != null)
            {
                _context.Cars.Remove(car_entry); 
                _context.SaveChanges();
            }
            return RedirectToPage("/Cars");
        }
    }
}
