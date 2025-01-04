using Xunit.Gherkin.Quick;
using Project_Testing_Joachim_Adomako;

namespace AcceptanceTesting.StepDefinition
{
    [FeatureFile("./Features/Reorder.feature")]
    public sealed class ReorderStepDefinition : Feature
    {
        private const string mockoonUrl = "http://localhost:3000/products";
        private readonly IProductService _productService;
        private readonly Reorder _reorder;
        private List<Product> _reorderList;
        private List<Product> _products;

        public ReorderStepDefinition()
        {
            _productService = new MockProductService(mockoonUrl);
            _reorder = new Reorder(_productService);
            _reorderList = new List<Product>();
            _products = new List<Product>();
        }

        [Given(@"the product ""(.*)"" has a current stock of (.*), a minimum stock of (.*), and an expected demand of (.*)")]
        public void GivenTheProductHasAStock(string name, int currentStock, int minStock, int expectedDemand)
        {
            var product = new Product
            {
                Name = name,
                CurrentStock = currentStock,
                MinStock = minStock,
                ExpectedDemand = expectedDemand
            };
            _products.Add(product);
            _productService.SetProducts(_products);
        }

        [When(@"I determine the reorder list")]
        public void WhenIDetermineTheReorderList()
        {
            _reorderList = _reorder.DetermineReorder();
        }

        [Then(@"the reorder list should be empty")]
        public void ThenTheReorderListShouldBeEmpty()
        {
            Assert.Empty(_reorderList);
        }

        [Then(@"the reorder list should contain ""(.*)""")]
        public void ThenTheReorderListShouldContain(string expectedProductName)
        {
            Assert.Contains(_reorderList, p => p.Name == expectedProductName);
        }
    }

    public class MockProductService : IProductService
    {
        private readonly string _url;
        private List<Product> _products;

        public MockProductService(string url)
        {
            _url = url;
            _products = new List<Product>();
        }

        public void SetProducts(List<Product> products)
        {
            _products = products;
        }

        public List<Product> GetProducts()
        {
            return _products;
        }

        public string Url
        {
            get => _url;
            set => throw new NotImplementedException();
        }
    }
}