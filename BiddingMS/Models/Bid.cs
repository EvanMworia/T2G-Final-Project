namespace BiddingMS.Models
{
    public class Bid
    {
        public Guid BidId { get; set; }
        public Guid PieceId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public double Price { get; set; }

    }
}
