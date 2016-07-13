using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Inventory.Domain
{
    public class InventoryProcessor
    {
        public void UpdateQuality(IList<Item> items)
        {
            for (var i = 0; i < items.Count; i++)
            {
                ProcessInventoryItem(items[i] as InventoryItem);
            }
        }

        public void ProcessInventoryItem(InventoryItem item)
        {
            UpdateSellIn(item);

            var qualityAdjRule = GetQualityAdjustmentRule(item);

            UpdateQuality(item, qualityAdjRule);
        }

        private void UpdateSellIn(InventoryItem item)
        {
            if (item.Type != ItemType.Fixed)
                item.SellIn--;
        }

        private Tuple<int?, int?, QualityAdjustment, int?> GetQualityAdjustmentRule(InventoryItem item)
        {
            var qualityAdjRule = item.QualityAdjustmentRules.First(
                r =>
                (r.Item1 == null || r.Item1.Value <= item.SellIn) &&
                (r.Item2 == null || r.Item2.Value >= item.SellIn));
            return qualityAdjRule;
        }

        private void UpdateQuality(InventoryItem item, Tuple<int?, int?, QualityAdjustment, int?> qualityAdjRule)
        {
            if (qualityAdjRule.Item3 == QualityAdjustment.Increase && item.Quality < 50)
                item.Quality += qualityAdjRule.Item4.Value;
            else if (qualityAdjRule.Item3 == QualityAdjustment.Decrease && item.Quality > 0)
                item.Quality -= qualityAdjRule.Item4.Value;
            else if (qualityAdjRule.Item3 == QualityAdjustment.ZeroOut)
                item.Quality = 0;
        }
    }
}
