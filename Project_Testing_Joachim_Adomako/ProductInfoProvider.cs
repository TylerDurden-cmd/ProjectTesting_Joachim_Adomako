using System.Collections.Generic;
using System.Linq;

namespace Project_Testing_Joachim_Adomako
{
    public class ProductInfoProvider : IProductService
    {
        private readonly List<Product> _products = new List<Product>
        {
            new Product { Name = "Playstation 5", CurrentStock = 10, MinStock = 5, ExpectedDemand = 20 },
            new Product { Name = "Xbox Series X", CurrentStock = 15, MinStock = 10, ExpectedDemand = 15 }
        };

        public string Url { get; set; }

        public List<Product> GetProducts()
        {
            return _products;
        }

        public void SetProducts(List<Product> product)
        {
            throw new NotImplementedException();
        }
    }
}