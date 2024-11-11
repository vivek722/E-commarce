using E_commerce.Ef.Core.Product;

namespace E_commarceWebApi.RequestModel
{
    public class ProductDto
    {
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public decimal ProductOrignalprice { get; set; }
        public decimal ProductActualprice { get; set; }
        public string SupplierId { get; set; }
        public List<IFormFile> ProductImag { get; set; }
    }
}
