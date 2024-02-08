using System.ComponentModel.DataAnnotations;

namespace ArtGalleryFrontend.Models.ArtProducts
{
    public class ArtDto
    {
        [Required]
        public Guid PieceId { get; set; }
        [Required]
        public Guid SellerID { get; set; }
        [Required]
        public string SellerName { get; set; } = string.Empty;
        [Required]
        public string ProductName { get; set; } = string.Empty;
        [Required]
        public string ProductPicture { get; set; } = string.Empty;
        //will be gotten from the category
        [Required]
        public string CategoryId { get; set; } = string.Empty;
        [Required]
        public double StartBidPrice { get; set; }
        [Required]
        public double HighestBid { get; set; }
        [Required]
        public string Status { get; set; } = "Active";
        [Required]
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(3);
    }
}
