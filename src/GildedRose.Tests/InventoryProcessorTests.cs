using GildedRose.Inventory.Domain;
using System;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
    /// <summary>
    /// Unit tests to cover the InventoryProcessor class.
    /// </summary>
    public class InventoryProcessorTests
    {
        private Item CreateDepreciatingItem(int sellIn, int quality)
        {
            Item item = new InventoryItem { Type = ItemType.Deprecating, Name = "+5 Dexterity Vest", SellIn = sellIn, Quality = quality,
                QualityRules =
                {
                    new QualityRule() { MinSellIn = null, MaxSellIn = -1, Adjustment = QualityAdjustment.Decrease, Rate = 2 },
                    new QualityRule() { MinSellIn = 0, MaxSellIn = null, Adjustment = QualityAdjustment.Decrease, Rate = 1 }
                }
            };
            return item;
        }

        private Item CreateDoubleRateDepreciatingItem(int sellIn, int quality)
        {
            Item item = CreateDepreciatingItem(sellIn, quality);
            item.Name = "Conjured";
            foreach (var qualityRule in ((InventoryItem)item).QualityRules)
                qualityRule.Rate *= 2;
            return item;
        }

        private Item CreateAppreciatingItem(int sellIn, int quality)
        {
            Item item = new InventoryItem { Type = ItemType.Appreciating, Name = "Aged Brie", SellIn = sellIn, Quality = quality,
                QualityRules =
                {
                    new QualityRule() { MinSellIn = null, MaxSellIn = -1, Adjustment = QualityAdjustment.Increase, Rate = 2 },
                    new QualityRule() { MinSellIn = 0, MaxSellIn = null, Adjustment = QualityAdjustment.Increase, Rate = 1 }
                }
            };
            return item;
        }

        private Item CreateAppreciatingItemWithVariableQualityRate(int sellIn, int quality)
        {
            Item item = new InventoryItem { Type = ItemType.AppreciatingTiered, Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality,
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

        private Item CreateFixedQualityItem(int sellIn, int quality)
        {
            Item item = new InventoryItem { Type = ItemType.Fixed, Name = "Sulfuras, Hand of Ragnaros", SellIn = sellIn, Quality = quality,
                QualityRules =
                {
                    new QualityRule() { MinSellIn = null, MaxSellIn = null, Adjustment = QualityAdjustment.None, Rate = null }
                }
            };
            return item;
        }

        [Fact]
        public void UpdateQualityTest_DepreciatingItem_BeforeSellByDate()
        {
            Item item = CreateDepreciatingItem(10, 20);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });
            
            Assert.Equal(9, item.SellIn);
            Assert.Equal(19, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_DepreciatingItem_BeforeSellByDate_MinQualityReached()
        {
            Item item = CreateDepreciatingItem(6, 0);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(5, item.SellIn);
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_DepreciatingItem_AfterSellByDate()
        {
            Item item = CreateDepreciatingItem(-1, 20);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(-2, item.SellIn);
            Assert.Equal(18, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_DepreciatingItem_AfterSellByDate_MinQualityReached()
        {
            Item item = CreateDepreciatingItem(-1, 0);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(-2, item.SellIn);
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_DepreciatingItem_DoubleRate_BeforeSellByDate()
        {
            Item item = CreateDoubleRateDepreciatingItem(10, 20);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(9, item.SellIn);
            Assert.Equal(18, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_DepreciatingItem_DoubleRate_BeforeSellByDate_MinQualityReached()
        {
            Item item = CreateDoubleRateDepreciatingItem(6, 0);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(5, item.SellIn);
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_DepreciatingItem_DoubleRate_AfterSellByDate()
        {
            Item item = CreateDoubleRateDepreciatingItem(-1, 20);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(-2, item.SellIn);
            Assert.Equal(16, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_DepreciatingItem_DoubleRate_AfterSellByDate_MinQualityReached()
        {
            Item item = CreateDoubleRateDepreciatingItem(-1, 0);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(-2, item.SellIn);
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_AppreciatingItem_BeforeSellByDate()
        {
            Item item = CreateAppreciatingItem(2, 0);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(1, item.SellIn);
            Assert.Equal(1, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_AppreciatingItem_BeforeSellByDate_MaxQualityReached()
        {
            Item item = CreateAppreciatingItem(2, 50);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(1, item.SellIn);
            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_AppreciatingItem_AfterSellByDate()
        {
            Item item = CreateAppreciatingItem(-1, 0);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(-2, item.SellIn);
            Assert.Equal(2, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_AppreciatingItem_AfterSellByDate_MaxQualityReached()
        {
            Item item = CreateAppreciatingItem(-1, 50);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(-2, item.SellIn);
            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_AppreciatingItem_VariableQualityRate_BeforeSellByDate_Tier1()
        {
            Item item = CreateAppreciatingItemWithVariableQualityRate(15, 20);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(14, item.SellIn);
            Assert.Equal(21, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_AppreciatingItem_VariableQualityRate_BeforeSellByDate_Tier2()
        {
            Item item = CreateAppreciatingItemWithVariableQualityRate(9, 20);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(8, item.SellIn);
            Assert.Equal(22, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_AppreciatingItem_VariableQualityRate_BeforeSellByDate_Tier3()
        {
            Item item = CreateAppreciatingItemWithVariableQualityRate(2, 20);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(1, item.SellIn);
            Assert.Equal(23, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_AppreciatingItem_VariableQualityRate_AfterSellByDate()
        {
            Item item = CreateAppreciatingItemWithVariableQualityRate(-1, 20);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(-2, item.SellIn);
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_FixedQualityItem()
        {
            Item item = CreateFixedQualityItem(0, 80);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(0, item.SellIn);
            Assert.Equal(80, item.Quality);
        }
    }
}
