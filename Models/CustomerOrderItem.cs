using Microsoft.Build.Framework;

namespace CustomerOrderItem.Models
{
    public class CustomerOrderItem1
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }

    }
}
