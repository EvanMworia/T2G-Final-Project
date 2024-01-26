namespace ArtProducts.Models.DTOs
{
    public class AddArtPieceDTO
    {
        public string ProductName { get; set; } = string.Empty;
        public string ProductPicture { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        //will be gotten from the category
        public string CategoryId { get; set; } = string.Empty;
        public int StartBidPrice { get; set; }

        
    }
}
