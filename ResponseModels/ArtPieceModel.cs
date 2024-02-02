using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponseModels
{
    public class ArtPieceModel
    {
        public Guid PieceId { get; set; }
        public Guid SellerID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductPicture { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        //will be gotten from the category
        public string CategoryId { get; set; } = string.Empty;
        public double StartBidPrice { get; set; }
        public double HighestBid { get; set; }
        public string Status { get; set; } = "Active";

        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(3);
    }
}
