using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ObscurusShop.Api.Controllers;
using ObscurusShop.Api.Models;
using ObscurusShop.Api.Data;


namespace ObscurusShop.Tests
{
    public class GuitarsControllerTests
    {   

        private static AppDbContext GetInMemoryDb()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public async Task Post_Creates_New_Guitar()
        {
            // Arrange
            var context = GetInMemoryDb();
            var controller = new GuitarsController(context);

            var guitar = new Guitar
            {
                Brand = "Fender",
                Model = "Stratocaster",
                Price = 2000
            };

            // Act
            var result = await controller.Create(guitar);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnValue = Assert.IsType<Guitar>(createdResult.Value);
            Assert.Equal("Fender", returnValue.Brand);
        }

        [Fact]
        public async Task Get_Retruns_Guitar_When_Exists()
        {
            var context = GetInMemoryDb();
            var guitar = new Guitar { Brand = "Gibson", Model = "Les Paul", Price = 3000 };
            context.Guitars.Add(guitar);
            await context.SaveChangesAsync();

            var controller = new GuitarsController(context);

            var result = await controller.GetById(guitar.Id);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var guitarResult = Assert.IsType<Guitar>(okResult.Value);
            Assert.Equal("Gibson", guitarResult.Brand);
            Assert.Equal("Les Paul", guitarResult.Model);
            Assert.Equal(3000, guitarResult.Price);
        }

        [Fact]
        public async Task Put_Updates_Guitar()
        {
            var context = GetInMemoryDb();
            var guitar = new Guitar { Brand = "Ibanez", Model = "RG550", Price = 1200 };
            context.Guitars.Add(guitar);
            await context.SaveChangesAsync();
            
            var controller = new GuitarsController(context);

            var updatedGuitar = new Guitar { Brand = "Ibanez", Model = "RG550", Price = 1500 };

            var result = await controller.Update(guitar.Id, updatedGuitar); 

            Assert.IsType<NoContentResult>(result);
            var guitarFromDb = await context.Guitars.FindAsync(guitar.Id);

            Assert.Equal("RG550", guitarFromDb.Model);
        }

        [Fact]
        public async Task Delete_Removes_Guitar()
        {
            var context = GetInMemoryDb();
            var guitar = new Guitar { Brand = "ESP", Model = "Horizon", Price = 3300 };
            context.Guitars.Add(guitar);
            await context.SaveChangesAsync();

            var controller = new GuitarsController(context);

            var result = await controller.Delete(guitar.Id);

            Assert.IsType<NoContentResult>(result);
            Assert.Null(await context.Guitars.FindAsync(guitar.Id));
        }
    }
}
