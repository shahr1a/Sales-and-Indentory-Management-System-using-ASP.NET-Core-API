using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BusinessEntities
{
    public class DealerSelfCreateModel
    {
        public int DealerId { get; set; }
        public string DealerUsername { get; set; } = null!;
        public string? DealerPassword { get; set; }
    }
}
