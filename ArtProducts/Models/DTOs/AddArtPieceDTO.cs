namespace ArtProducts.Models.DTOs
{
    public class AddArtPieceDTO
    {
      
        public string ProductName { get; set; } = string.Empty;
        public string ProductPicture { get; set; } = string.Empty;
        //will be gotten from the category
        public string CategoryId { get; set; } = string.Empty;
        public double StartBidPrice { get; set; }
        
        public string Status { get; set; } = "Active";

        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(3);


    }
}
