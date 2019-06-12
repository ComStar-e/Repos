using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            if(!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product  { Name = "Kayak", Description = "A boat for one person", Category = "Watersport", Price = 275 },
                    new Product { Name = "Lifejacket", Description = "Protective and fashionable", Category = "Watersport", Price = 48.95M },
                    new Product { Name = "Soocer Ball", Description = "FIFA-approved size and weight", Category = "Soccer", Price = 19.50M },
                    new Product { Name = "Corner Flags", Description = "Give your playing field a proffesional touch", Category = "Soccer", Price = 275 },
                    new Product { Name = "Stadium", Description = "Flat-packed 35,000-seat stadium", Category = "Soccer", Price = 79500 },
                    new Product { Name = "Thinking Cap", Description = "Improve brain effcioency by 75%", Category = "Chess", Price = 16 },
                    new Product { Name = "Unsteady Chair", Description = "Secretly give your opponent а disadvantage", Category = "Chess", Price = 29.95M },
                    new Product { Name = "Human Chess Board", Description = "А fun game for the family", Category = "Chess", Price = 75 },
                    new Product { Name = "Bling-Bling King", Description = "Gold-plated, diamond-studded King", Category = "Chess", Price = 1200}
                    );
                context.SaveChanges();
            }

        }
    }
}
