namespace E_commarceWebApi.RequestModel
{
    public class ReviewDto
    {
        public int ReviewId { get; set; }        
        public int CustomerId { get; set; }       
        public int ProductId { get; set; }       
        public int Rating { get; set; }          
        public string ReviewText { get; set; }
    }
}
