using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project_Testing_Joachim_Adomako
{
    public class ProductInfoProviderAPI : IProductService
    {
        private string url = "http://localhost:3001/api/products";

        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        public List<Product> GetProducts()
        {
            using (var httpClient = new HttpClient())
            {
                var httpResponse = httpClient.GetAsync(url).GetAwaiter().GetResult();
                var response = httpResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                return JsonSerializer.Deserialize<List<Product>>(response);
            }
        }

        public void SetProducts(List<Product> product)
        {
            throw new NotImplementedException();
        }
    }
}