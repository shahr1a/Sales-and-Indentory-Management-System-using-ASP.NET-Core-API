using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BusinessEntities
{
    public class InventoryPostModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string? Description { get; set; }
        public double BuyingPrice { get; set; }
        public bool InStock { get; set; }
        public int? Stock { get; set; }
        public int CategoryId { get; set; }
    }
}
