using Moq;
using Project_Testing_Joachim_Adomako;
using System.Security.Cryptography.X509Certificates;

namespace ProjectTesting_Joachim_Adomako
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void DetermineReorder_Returns_EmptyList_WhenStockSuffictient()
        {
            var product = new List<Product>
            {
                new Product{ Name = "Playstation 5", CurrentStock = 30, ExpectedDemand = 5, MinStock = 12 },
                new Product{ Name = "Iphone 14", CurrentStock = 30, ExpectedDemand = 5, MinStock = 10 },
                new Product{ Name = "Zenbook", CurrentStock = 20, ExpectedDemand = 5, MinStock = 18 }
            };

            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(x => x.GetProducts()).Returns(product);
            var reorder = new Reorder(mockProductService.Object);

            var result = reorder.DetermineReorder();

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void DetermineReorder_Returns_ExceptionWhenCurrentStock_LessThen_0()
        {
            var products = new List<Product>
            {
                new Product{Name = "JBL Speaker", CurrentStock = -1 , ExpectedDemand = 20, MinStock = 3},
            };

            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(x => x.GetProducts()).Returns(products);
            var reorder = new Reorder(mockProductService.Object);

            Assert.ThrowsException<ArgumentException>(() => reorder.DetermineReorder());
        }

        [TestMethod]
        public void DetermineReorder_AddsProductToReorderList_WhenCurrentStockLessThanMinStock()
        {
            var products = new List<Product>
            {
                new Product{Name = "JBL Speaker", CurrentStock = 2, ExpectedDemand = 20, MinStock = 3}
            };

            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(x => x.GetProducts()).Returns(products);
            var reorder = new Reorder(mockProductService.Object);

            var result = reorder.DetermineReorder();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("JBL Speaker", result[0].Name);
        }

        [TestMethod]
        public void DetermineReorder_DoesNotAddProductToReorderList_WhenCurrentStockGreaterThanMinStock()
        {
            var products = new List<Product>
            {
                new Product{Name = "JBL Speaker", CurrentStock = 4, ExpectedDemand = 20, MinStock = 3},
            };

            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(x => x.GetProducts()).Returns(products);
            var reorder = new Reorder(mockProductService.Object);

            var result = reorder.DetermineReorder();

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void DetermineReorder_HandlesMultipleProductsWithMixedStockLevels()
        {
            var products = new List<Product>
            {
                new Product{Name = "JBL Speaker", CurrentStock = 2, ExpectedDemand = 20, MinStock = 3},
                new Product{Name = "Playstation 5", CurrentStock = 30, ExpectedDemand = 5, MinStock = 12},
                new Product{Name = "Iphone 14", CurrentStock = 10, ExpectedDemand = 5, MinStock = 10},
                new Product{Name = "Zenbook", CurrentStock = 20, ExpectedDemand = 5, MinStock = 18}
            };

            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(x => x.GetProducts()).Returns(products);
            var reorder = new Reorder(mockProductService.Object);

            var result = reorder.DetermineReorder();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("JBL Speaker", result[0].Name);
        }
    }
}