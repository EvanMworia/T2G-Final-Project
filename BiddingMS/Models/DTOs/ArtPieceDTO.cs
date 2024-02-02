namespace BiddingMS.Models.DTOs
{
    public class ArtPieceDTO
    {
        public Guid PieceId { get; set; }
        public Guid SellerID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductPicture { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string CategoryId { get; set; } = string.Empty;
        public double StartBidPrice { get; set; }
        public double HighestBid { get; set; }
        public string Status { get; set; }

        public DateTime EndDate { get; set; }
    }
}
