using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BusinessEntities
{
    public class SaleModel
    {
        public int SaleId { get; set; }
        public int Product { get; set; }
        public int Dealer { get; set; }
        public double SellingPrice { get; set; }
        public DateTime SellingDate { get; set; }
        public bool IsPaid { get; set; }
        public double? RemainingBalance { get; set; }
        public int Quantity { get; set; }
        public bool? Approval { get; set; }

        public InventoryModel Inventory { get; set; } = null!;
        public DealerModel Dealer { get; set; } = null!;
    }
}
