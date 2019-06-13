using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using SportsStore.Controllers;
using SportsStore.Models;
using SportsStore.Models.ViewModels;
using Xunit;

namespace SportsStore.Tests
{
    public class ProductControllerTests
    {

        [Fact]
        public void Can_Send_Pagination_View_Model()
        {
            // Организаци
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[] {
                new Product {ProductID = 1, Name ="P1"},
                new Product {ProductID = 2, Name ="P2"},
                new Product {ProductID = 3, Name ="P3"},
                new Product {ProductID = 4, Name ="P4"},
                new Product {ProductID = 5, Name ="P5"}
            }).AsQueryable<Product>());

            // Организация
            ProductController controller = new ProductController(mock.Object) { PageSize = 3 };

            //Действие
            ProductsListViewModel result = controller.List(2).ViewData.Model as ProductsListViewModel;

            // Утверждение
            PagingInfo pageinfo = result.PagingInfo;
            Assert.Equal(2, pageinfo.CurrentPage);
            Assert.Equal(3, pageinfo.ItemsPerPage);
            Assert.Equal(5, pageinfo.TotalItems);
            Assert.Equal(2, pageinfo.TotalPages);
        }






        [Fact]
        public void Can_Paginate()
        {
            // Organizaciya
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product {ProductID = 1, Name ="P1"},
                new Product {ProductID = 2, Name ="P2"},
                new Product {ProductID = 3, Name ="P3"},
                new Product {ProductID = 4, Name ="P4"},
                new Product {ProductID = 5, Name ="P5"}
            }).AsQueryable<Product>());

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            // Acition
            //IEnumerable<Product> result = controller.List(2).ViewData.Model as IEnumerable<Product>;
            ProductsListViewModel result = controller.List(2).ViewData.Model as ProductsListViewModel;

            // Utverjdenie
            Product[] prodArray = result.Products.ToArray();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("P4", prodArray[0].Name);
            Assert.Equal("P5", prodArray[1].Name);

        }
    }
}
