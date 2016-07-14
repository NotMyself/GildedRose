using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Inventory.Domain
{
    public class QualityRule
    {
        public int? MinSellIn { get; set; }
        public int? MaxSellIn { get; set; }
        public QualityAdjustment Adjustment { get; set; }
        public int? Rate { get; set; }
    }
}
