using System;

namespace GildedRose.Inventory.Domain.Entities
{
    /// <summary>
    /// Represents a rule that indicates how an inventory item's quality behaves over time.
    /// </summary>
    public class QualityRule
    {
        public QualityRule()
            : base()
        {
        }

        public int? MinSellIn { get; set; }
        public int? MaxSellIn { get; set; }
        public QualityAdjustment Adjustment { get; set; }
        public int? Rate { get; set; }
    }
}
