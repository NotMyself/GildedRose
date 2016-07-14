using System;

namespace GildedRose.Inventory.Domain.Entities
{
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
