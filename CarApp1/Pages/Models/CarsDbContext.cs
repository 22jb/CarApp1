﻿using Microsoft.EntityFrameworkCore;

namespace CarApp1.Pages.Models
{
    public class CarsDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("CarsDb");
        }
        public void SeedData()
        {
            if (Cars.Any())
                return;
            var cars = new List<Car>
            {
                new Car
                {
                    Brand = "Toyota",
                    Model = "Camry",
                    Colour = "Red",
                    EngineType = "Petrol",
                    EngineSize = "2.5L",
                    ImagePath = "/uploads/t-camry.jpg" 
                },
                new Car
                {
                    Brand = "Honda",
                    Model = "Civic",
                    Colour = "Blue",
                    EngineType = "Gasoline",
                    EngineSize = "1.8L",
                    ImagePath = "/uploads/h-civic.jpg" 
                },
                new Car
                {
                    Brand = "Ford",
                    Model = "Mustang",
                    Colour = "Yellow",
                    EngineType = "Petrol",
                    EngineSize = "5.0L",
                    ImagePath = "/uploads/f-mustang.jpg"
                },
                new Car
                {
                    Brand = "Chevrolet",
                    Model = "Corvette",
                    Colour = "Black",
                    EngineType = "Gasoline",
                    EngineSize = "6.2L",
                    ImagePath = "/uploads/c-corvette.jpg"
                },
                new Car
                {
                    Brand = "BMW",
                    Model = "X5",
                    Colour = "White",
                    EngineType = "Diesel",
                    EngineSize = "3.0L",
                    ImagePath = "/uploads/b-x5.jpg"
                },
            };

            Cars.AddRange(cars);
            SaveChanges();
        }
    }
}
