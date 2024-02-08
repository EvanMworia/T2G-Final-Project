﻿namespace ArtGalleryFrontend.Models.ArtProducts
{
    public class ArtRequestDto
    {
        public Guid PieceId { get; set; }
        public Guid SellerID { get; set; }
        public string SellerName { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string ProductPicture { get; set; } = string.Empty;
        //will be gotten from the category
        public string CategoryId { get; set; } = string.Empty;
        public double StartBidPrice { get; set; }
        public double HighestBid { get; set; }
        public string Status { get; set; } = "Active";
    }
}
