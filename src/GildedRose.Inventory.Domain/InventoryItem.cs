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
            QualityRules = new List<QualityRule>();
        }

        public ItemType Type { get; set; }
        public List<QualityRule> QualityRules { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - Quality={1}, SellIn={2}", Name, Quality, SellIn);
        }
    }
}
