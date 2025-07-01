using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARetailOrder.ApiService.DataContext.Models
{
    [Table("Customers")]
    public class Customer
    {
        public Guid ID { get; set; }
        [Required]
        [StringLength(200)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(200)]
        public string LastName { get; set; }
        public string? Email { get; set; }
        [Required]
        [StringLength(11)]
        public string PhoneNo { get; set; }
        [Required]
        [StringLength(500)]
        public string ShippingAddress { get; set; }
        [Required]
        [StringLength(500)]
        public string BillingAddress { get; set; }
        //Auditlogs
        public DateTime CreationTime { get; set; }
        public int CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public int? LastModifierUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
        public int DeleterUserId { get; set; }
    }
}
