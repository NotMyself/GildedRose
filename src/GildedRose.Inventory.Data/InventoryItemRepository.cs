using GildedRose.Inventory.Domain.Entities;
using System.Collections.Generic;

namespace GildedRose.Inventory.Data
{
    /// <summary>
    /// Responsible for all data access for inventory items.
    /// </summary>
    public class InventoryItemRepository
    {
        public InventoryItemRepository()
            : base()
        {
        }

        public List<Item> LoadInventoryItems()
        {
            List<Item> inventoryItems = new List<Item>()
            {
                new InventoryItem {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20, Type = ItemType.Deprecating, QualityRules =
                {
                    new QualityRule() { MinSellIn = null, MaxSellIn = -1, Adjustment = QualityAdjustment.Decrease, Rate = 2 },
                    new QualityRule() { MinSellIn = 0, MaxSellIn = null, Adjustment = QualityAdjustment.Decrease, Rate = 1 }
                }},
                new InventoryItem {Name = "Aged Brie", SellIn = 2, Quality = 0, Type = ItemType.Appreciating, QualityRules =
                {
                    new QualityRule() { MinSellIn = null, MaxSellIn = -1, Adjustment = QualityAdjustment.Increase, Rate = 2 },
                    new QualityRule() { MinSellIn = 0, MaxSellIn = null, Adjustment = QualityAdjustment.Increase, Rate = 1 }
                }},
                new InventoryItem {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7, Type = ItemType.Deprecating, QualityRules =
                {
                    new QualityRule() { MinSellIn = null, MaxSellIn = -1, Adjustment = QualityAdjustment.Decrease, Rate = 2 },
                    new QualityRule() { MinSellIn = 0, MaxSellIn = null, Adjustment = QualityAdjustment.Decrease, Rate = 1 }
                }},
                new InventoryItem {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80, Type = ItemType.Fixed, QualityRules =
                {
                    new QualityRule() { MinSellIn = null, MaxSellIn = null, Adjustment = QualityAdjustment.None, Rate = null }
                }},
                new InventoryItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20, Type = ItemType.AppreciatingTiered, QualityRules =
                {
                    new QualityRule() { MinSellIn = null, MaxSellIn = -1, Adjustment = QualityAdjustment.SetToMin, Rate = null },
                    new QualityRule() { MinSellIn = 0, MaxSellIn = 5, Adjustment = QualityAdjustment.Increase, Rate = 3 },
                    new QualityRule() { MinSellIn = 6, MaxSellIn = 10, Adjustment = QualityAdjustment.Increase, Rate = 2 },
                    new QualityRule() { MinSellIn = 11, MaxSellIn = null, Adjustment = QualityAdjustment.Increase, Rate = 1 }
                }},
                new InventoryItem {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6, Type = ItemType.Deprecating, QualityRules =
                {
                    new QualityRule() { MinSellIn = null, MaxSellIn = -1, Adjustment = QualityAdjustment.Decrease, Rate = 4 },
                    new QualityRule() { MinSellIn = 0, MaxSellIn = null, Adjustment = QualityAdjustment.Decrease, Rate = 2 }
                }}
            };

            return inventoryItems;
        }
    }
}
