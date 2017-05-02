using GildedRose.Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Tests
{
    /// <summary>
    /// Provides common test data and assertion logic used by all inventory tests.
    /// </summary>
    public static class InventoryTestUtility
    {
        public static Item CreateDepreciatingItem(int sellIn, int quality)
        {
            Item item = new InventoryItem
            {
                Type = ItemType.Deprecating,
                Name = "+5 Dexterity Vest",
                SellIn = sellIn,
                Quality = quality,
                QualityRules =
                {
                    new QualityRule() { MinSellIn = null, MaxSellIn = -1, Adjustment = QualityAdjustment.Decrease, Rate = 2 },
                    new QualityRule() { MinSellIn = 0, MaxSellIn = null, Adjustment = QualityAdjustment.Decrease, Rate = 1 }
                }
            };
            return item;
        }

        public static Item CreateDoubleRateDepreciatingItem(int sellIn, int quality)
        {
            Item item = CreateDepreciatingItem(sellIn, quality);
            item.Name = "Conjured Mana Cake";
            foreach (var qualityRule in ((InventoryItem)item).QualityRules)
                qualityRule.Rate *= 2;
            return item;
        }

        public static Item CreateAppreciatingItem(int sellIn, int quality)
        {
            Item item = new InventoryItem
            {
                Type = ItemType.Appreciating,
                Name = "Aged Brie",
                SellIn = sellIn,
                Quality = quality,
                QualityRules =
                {
                    new QualityRule() { MinSellIn = null, MaxSellIn = -1, Adjustment = QualityAdjustment.Increase, Rate = 2 },
                    new QualityRule() { MinSellIn = 0, MaxSellIn = null, Adjustment = QualityAdjustment.Increase, Rate = 1 }
                }
            };
            return item;
        }

        public static Item CreateAppreciatingItemWithVariableQualityRate(int sellIn, int quality)
        {
            Item item = new InventoryItem
            {
                Type = ItemType.AppreciatingTiered,
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = sellIn,
                Quality = quality,
                QualityRules =
                {
                    new QualityRule() { MinSellIn = null, MaxSellIn = -1, Adjustment = QualityAdjustment.SetToMin, Rate = null },
                    new QualityRule() { MinSellIn = 0, MaxSellIn = 5, Adjustment = QualityAdjustment.Increase, Rate = 3 },
                    new QualityRule() { MinSellIn = 6, MaxSellIn = 10, Adjustment = QualityAdjustment.Increase, Rate = 2 },
                    new QualityRule() { MinSellIn = 11, MaxSellIn = null, Adjustment = QualityAdjustment.Increase, Rate = 1 }
                }
            };
            return item;
        }

        public static Item CreateFixedQualityItem(int sellIn, int quality)
        {
            Item item = new InventoryItem
            {
                Type = ItemType.Fixed,
                Name = "Sulfuras, Hand of Ragnaros",
                SellIn = sellIn,
                Quality = quality,
                QualityRules =
                {
                    new QualityRule() { MinSellIn = null, MaxSellIn = null, Adjustment = QualityAdjustment.None, Rate = null }
                }
            };
            return item;
        }
    }
}
