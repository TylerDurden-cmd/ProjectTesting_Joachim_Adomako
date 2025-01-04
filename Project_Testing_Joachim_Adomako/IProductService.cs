using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Testing_Joachim_Adomako
{
    public interface IProductService
    {
        public string Url { get; set; }
        List<Product> GetProducts();
        public void SetProducts(List<Product> product);
    }
}
