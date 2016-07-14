using System.Collections.Generic;

namespace GildedRose.Inventory.Domain.Entities
{
    /// <summary>
    /// Represents an inventory item.
    /// </summary>
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
