namespace E_commarceWebApi.RequestModel
{
    public class InventoryDto
    {
        public int product_id { get; set; }
        public string WarehouseName { get; set; }
        public string Location { get; set; }
        public int Quantity { get; set; }
    }
}