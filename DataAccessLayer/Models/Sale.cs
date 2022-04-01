using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Sale
    {
        [Key]
        public int SaleMasterId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string? SaleId { get; set; }

        [Required]
        public int ProductId { get; set; }

        public Inventory? Inventory { get; set; }

        [Required]
        public int DealerId { get; set; }

        public Dealer? Dealer { get; set; }

        public float SellingPrice { get; set; }

        public DateTime SoldOn { get; set; }

        public bool IsPaid { get; set; }

        public float RemainingBalance { get; set; }

        [AllowNull]
        [Column(TypeName = "nvarchar(50)")]
        public string? PaymentMethod { get; set; }

        public int Quantity { get; set; }

        public bool Approval { get; set; }


    }
}
