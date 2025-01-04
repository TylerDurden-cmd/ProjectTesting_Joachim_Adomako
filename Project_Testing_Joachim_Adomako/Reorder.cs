using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Testing_Joachim_Adomako
{
    public class Reorder
    {
        private readonly IProductService _productService;
        public Reorder(IProductService productService)
        {
            _productService = productService;
        }

        public List<Product> DetermineReorder()
        {
            var products = _productService.GetProducts();
            var reorderList = new List<Product>();

            foreach (var product in products)
            {
                if (product.CurrentStock < 0)
                {
                    throw new ArgumentException("Current stock cannot be negative.");
                }

                if (product.CurrentStock < product.MinStock)
                {
                    product.ExpectedDemand = product.MinStock + product.ExpectedDemand - product.CurrentStock;
                    reorderList.Add(product);
                }
            }

            return reorderList;
        }
    }
}
