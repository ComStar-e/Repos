using System.Linq;
using SportsStore.Models;
using Xunit;

namespace SportsStore.Tests
{
    public class SportsStore
    {
        [Fact]
        public void Can_Add_New_lines()
        {
            //////////////////////////////////////           
            ///
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };


            //////////////
            ///
            Cart target = new Cart();

            /////////////
            ///
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);

            CartLine[] results = target.Lines.ToArray();

            /////////
            ///
            Assert.Equal(2, results.Length);
            Assert.Equal(p1, results[0].Product);
            Assert.Equal(p2, results[1].Product);
        }


        [Fact]
        public void Can_Quantity_for_existing_lines()
        {
            //////////////////////////////////////           
            ///
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };


            //////////////
            ///
            Cart target = new Cart();

            /////////////
            ///
            target.AddItem(p2, 1);
            target.AddItem(p1, 1);            
            target.AddItem(p1, 10);

            CartLine[] results = target.Lines.OrderBy(c => c.Product.ProductID).ToArray();

            /////////
            ///
            Assert.Equal(2, results.Length);
            Assert.Equal(11, results[0].Quantity);
            Assert.Equal(1, results[1].Quantity);
        }

        [Fact]
        public void Can_Remove_lines()
        {
            //////////////////////////////////////           
            ///
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };
            Product p3 = new Product { ProductID = 3, Name = "P3" };
                       
            //////////////
            ///
            Cart target = new Cart();

            /////////////
            ///
            target.AddItem(p1, 1);
            target.AddItem(p2, 3);
            target.AddItem(p3, 5);
            target.AddItem(p2, 2);

            target.RemoveLine(p2);

            /////////
            ///
            Assert.Equal(0 , target.Lines.Where(c => c.Product == p2).Count() );
            Assert.Equal(2, target.Lines.Count());
                                   
        }

        [Fact]
        public void Can_Calculate_Card_total()
        {
            //////////////////////////////////////           
            ///
            Product p1 = new Product { ProductID = 1, Name = "P1", Price = 100M };
            Product p2 = new Product { ProductID = 2, Name = "P2", Price = 50.50M };
            Product p3 = new Product { ProductID = 3, Name = "P3", Price = 49.54M };

            //////////////
            ///
            Cart target = new Cart();

            /////////////
            ///
            target.AddItem(p1, 2);
            target.AddItem(p2, 1);
            target.AddItem(p3, 1);


            decimal sum = target.ComputeTotalValue();           

            /////////
            ///
            Assert.Equal(300.04M, sum);
        }

        [Fact]
        public void Can_Clear_contents()
        {
            //////////////////////////////////////           
            ///
            Product p1 = new Product { ProductID = 1, Name = "P1", Price = 100M };
            Product p2 = new Product { ProductID = 2, Name = "P2", Price = 50.50M };
            Product p3 = new Product { ProductID = 3, Name = "P3", Price = 49.54M };

            //////////////
            ///
            Cart target = new Cart();

            /////////////
            ///
            target.AddItem(p1, 2);
            target.AddItem(p2, 1);
            target.AddItem(p3, 1);


            target.Clear();

            /////////
            ///
            Assert.Equal(0, target.Lines.Count());
        }



    }
}
