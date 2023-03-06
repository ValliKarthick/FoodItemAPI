using System;
using System.Collections.Generic;

namespace Web_Api___Scaffolded.Models
{
    public partial class OrderDetail
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; } = null!;
        public int? ContactNumber { get; set; }
        public string? FoodId { get; set; }
        public int Quantity { get; set; }
        public string HomeDelivery { get; set; } = null!;
        public decimal? TotalCost { get; set; }

        public virtual FoodItemDetail? Food { get; set; }
    }
}
