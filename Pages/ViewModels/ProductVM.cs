using CustomerOrderItem.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CustomerOrderItem.ViewModels
{
    public class ProductVM
    {
        public int ID { get; set; }
        [MaxLength(50)]
        [Required]
        public string ProductName { get; set; }
        [MaxLength(100)]
        [AllowNull]
        public string ProductDes { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
