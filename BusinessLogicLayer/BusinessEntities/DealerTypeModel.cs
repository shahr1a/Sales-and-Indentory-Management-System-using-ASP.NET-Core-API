using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BusinessEntities
{
    public class DealerTypeModel
    {
        [Key]
        public int DealerTypeId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Type { get; set; } = null!;
        public int? Discount { get; set; }
    }
}
