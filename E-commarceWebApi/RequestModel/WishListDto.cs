namespace E_commarceWebApi.RequestModel
{
    public class WishListDto
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public DateTime AddedDate { get; set; } = DateTime.UtcNow;
    }
}
