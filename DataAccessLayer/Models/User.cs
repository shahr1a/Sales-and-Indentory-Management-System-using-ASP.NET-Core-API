using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string? Username { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? Password { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? ContactNo { get; set; }

        [Required]
        public bool IsVerified { get; set; } = false;

        [Required]
        public bool IsAdmin { get; set; } = false;

        [Column(TypeName = "nvarchar(100)")]
        public string? FirstName { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? LastName { get; set; }
    }
}
