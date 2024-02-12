namespace ArtGalleryFrontend.Models.Bid_Models.DTOs
{
    public class ArtPieceResponseDto
    {
        public string ErrorMessage { get ; set; }  = string.Empty;
        public ArtPieceDTO  ArtPiece { get; set; }    
    }
}
