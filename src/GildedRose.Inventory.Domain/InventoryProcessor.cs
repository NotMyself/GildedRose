using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Inventory.Domain
{
    public class InventoryProcessor
    {
        private const int MIN_QUALITY = 0;
        private const int MAX_QUALITY = 50;

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

            var qualityRule = GetQualityRule(item);

            UpdateQuality(item, qualityRule);
        }

        private void UpdateSellIn(InventoryItem item)
        {
            if (item.Type != ItemType.Fixed)
                item.SellIn--;
        }

        private QualityRule GetQualityRule(InventoryItem item)
        {
            var qualityRule = item.QualityRules.First(
                r =>
                (r.MinSellIn == null || r.MinSellIn.Value <= item.SellIn) &&
                (r.MaxSellIn == null || r.MaxSellIn.Value >= item.SellIn));
            return qualityRule;
        }

        private void UpdateQuality(InventoryItem item, QualityRule qualityRule)
        {
            if (qualityRule.Adjustment == QualityAdjustment.Increase && item.Quality < MAX_QUALITY)
                item.Quality += qualityRule.Rate.Value;
            else if (qualityRule.Adjustment == QualityAdjustment.Decrease && item.Quality > MIN_QUALITY)
                item.Quality -= qualityRule.Rate.Value;
            else if (qualityRule.Adjustment == QualityAdjustment.SetToMin)
                item.Quality = MIN_QUALITY;
        }
    }
}
