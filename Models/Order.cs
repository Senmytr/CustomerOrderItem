using Microsoft.Build.Framework;

namespace CustomerOrderItem.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public DateTime OrderDate { get; set; }

        public ICollection<CustomerOrderItem1> CustomerOrderItems { get; set; }
    }
}
