using System;
using System.Collections.Generic;

namespace Web_Api___Scaffolded.Models
{
    public partial class FoodItemDetail
    {
        public FoodItemDetail()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public string FoodId { get; set; } = null!;
        public string ItemName { get; set; } = null!;
        public string? Cuisine { get; set; }
        public int AvailableQuantity { get; set; }
        public decimal CostPerItem { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
