namespace ArtGalleryFrontend.Models.Bid_Models.DTOs
{
    public class AddBidDTO
    {
        public Guid PieceId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public double Price { get; set; }
    }
}
