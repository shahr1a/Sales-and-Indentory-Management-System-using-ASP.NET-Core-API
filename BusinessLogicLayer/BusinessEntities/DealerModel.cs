using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BusinessEntities
{
    public class DealerModel
    {
        public int DealerId { get; set; }
        public string? DealerName { get; set; }
        public string? DealerLocation { get; set; }
        public string DealerUsername { get; set; } = null!;
        public string? DealerPassword { get; set; }
        public bool IsVerified { get; set; }
        public double? DealerDiscount { get; set; }
        public int? DealerType { get; set; }

        public virtual DealerType? DealerTypeNavigation { get; set; }
    }
}
