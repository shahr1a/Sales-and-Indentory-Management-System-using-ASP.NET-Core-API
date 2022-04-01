using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string? Title { get; set; }
    }
}
