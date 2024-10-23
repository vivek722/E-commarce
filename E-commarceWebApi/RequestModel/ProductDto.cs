namespace E_commarceWebApi.RequestModel
{
    public class ProductDto
    {
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public decimal ProductOrignalprice { get; set; }
        public decimal ProductActualprice { get; set; }
        public List<IFormFile> ProductImag { get; set; }
        public int SupplierId { get; set; }
    }
}
