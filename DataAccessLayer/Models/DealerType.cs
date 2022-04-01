using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class DealerType
    {
        [Key]
        public int DealerTypeId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Type { get; set; } = null!;
        [Column("discount")]
        public int? Discount { get; set; }
    }
}
