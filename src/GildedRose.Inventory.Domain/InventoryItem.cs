using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Inventory.Domain
{
    public class InventoryItem : Item
    {
        public InventoryItem()
            : base()
        {
            QualityAdjustmentRules = new List<Tuple<int?, int?, QualityAdjustment, int?>>();
        }

        public ItemType Type { get; set; }
        public List<Tuple<int?, int?, QualityAdjustment, int?>> QualityAdjustmentRules { get; set; }
    }
}
