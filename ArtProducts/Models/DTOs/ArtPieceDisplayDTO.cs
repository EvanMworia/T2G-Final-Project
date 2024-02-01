namespace ArtProducts.Models.DTOs
{
    public class ArtPieceDisplayDTO
    {
        public Guid PieceId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductPicture { get; set; } = string.Empty;
        public Guid SellerID { get; set; }
        public string UserName { get; set; } = string.Empty;
        //will be gotten from the category
        public string CategoryId { get; set; } = string.Empty;
        
        public double HighestBid { get; set; }
        public string Status { get; set; } = "Active";

        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(3);
    }
}
