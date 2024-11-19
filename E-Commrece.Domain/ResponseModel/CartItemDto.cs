namespace E_commarceWebApi.ResponseModel
{
    public class CartItemDto
    {

        public int AddToCartId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public decimal ProductOrignalprice { get; set; }
        public decimal ProductActualPrice { get; set; }
        public string ProductImag { get; set; }

    }
}
