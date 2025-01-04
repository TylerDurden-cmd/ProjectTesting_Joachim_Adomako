using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_Testing_Joachim_Adomako;

namespace Project_Testing_Integration_Joachim_Adomako
{
    [TestClass]
    public sealed class IntegrationTests
    {
        private IProductService _productService;
        private Reorder _reorder;

        [TestInitialize]
        public void TestInitialize()
        {
            _productService = new ProductInfoProviderAPI();
            _reorder = new Reorder(_productService);
        }

        [TestMethod]
        public void GetProducts_ReturnsProductList_FromMockAPI()
        {
            var products = _productService.GetProducts();

            var result = _reorder.DetermineReorder();

            Assert.AreEqual(0, result.Count); 
        }

        [TestMethod]
        public void DetermineReorder_AddsProductToReorderList_WhenCurrentStockLessThanMinStock()
        {
            var products = _productService.GetProducts();

            var result = _reorder.DetermineReorder();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Playstation 5", result[0].Name);
        }

        [TestMethod]
        public void DetermineReorder_DoesNotAddProductToReorderList_WhenCurrentStockEqualToMinStock()
        {
            var products = _productService.GetProducts();

            var result = _reorder.DetermineReorder();

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void DetermineReorder_DoesNotAddProductToReorderList_WhenCurrentStockGreaterThanMinStock()
        {
            var products = _productService.GetProducts();

            var result = _reorder.DetermineReorder();

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void DetermineReorder_HandlesMultipleProductsWithMixedStockLevels()
        {
            var products = _productService.GetProducts();

            var result = _reorder.DetermineReorder();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Playstation 5", result[0].Name);
            //deze gaat falen want outkomst is 0
        }
    }
}