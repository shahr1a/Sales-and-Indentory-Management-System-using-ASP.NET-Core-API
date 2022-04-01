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
    public class Inventory
    {
        [Key]
        public int ProductId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? ProductName { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string? Description { get; set; }

        public float BuyingPrice { get; set; }

        public bool InStock { get; set; }

        [AllowNull]
        public int Stock { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
