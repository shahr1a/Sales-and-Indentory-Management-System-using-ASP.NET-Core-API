using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Dealer
    {
        [Key]
        public int DealerId { get; set; }

        [Column(TypeName = "nvarchar(100)")]

        public string? DealerName { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string? DealerLocation { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string DealerUsername { get; set; } = null!;

        [Column(TypeName = "nvarchar(50)")]
        public string? DealerPassword { get; set; }

        public bool IsVerified { get; set; }

        public double? DealerDiscount { get; set; }

        public int? DealerTypeId { get; set; }

        public DealerType? DealerType { get; set; }
    }
}
