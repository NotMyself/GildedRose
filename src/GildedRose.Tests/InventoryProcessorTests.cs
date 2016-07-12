using GildedRose.Inventory.Domain;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
    /// <summary>
    /// Unit tests to cover the InventoryProcessor class.
    /// </summary>
    public class InventoryProcessorTests
    {
        private Item CreateStandardItem(int sellIn, int quality)
        {
            Item item = new Item { Name = "+5 Dexterity Vest", SellIn = sellIn, Quality = quality };
            return item;
        }

        private Item CreateAppreciatingItem(int sellIn, int quality)
        {
            Item item = new Item { Name = "Aged Brie", SellIn = sellIn, Quality = quality };
            return item;
        }

        private Item CreateAppreciatingItemWithVariableQualityRate(int sellIn, int quality)
        {
            Item item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality };
            return item;
        }

        private Item CreateFixedQualityItem(int sellIn, int quality)
        {
            Item item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = sellIn, Quality = quality };
            return item;
        }

        [Fact]
        public void UpdateQualityTest_StandardItem()
        {
            Item item = CreateStandardItem(10, 20);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });
            
            Assert.Equal(9, item.SellIn);
            Assert.Equal(19, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_StandardItem_PastSellByDate()
        {
            Item item = CreateStandardItem(-1, 20);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(-2, item.SellIn);
            Assert.Equal(18, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_StandardItem_PastSellByDate_NoQualityRemaining()
        {
            Item item = CreateStandardItem(-1, 0);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(-2, item.SellIn);
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_AppreciatingItem()
        {
            Item item = CreateAppreciatingItem(2, 0);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(1, item.SellIn);
            Assert.Equal(1, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_AppreciatingItem_MaxQuality()
        {
            Item item = CreateAppreciatingItem(2, 50);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(1, item.SellIn);
            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_AppreciatingItem_VariableQualityRate_Tier1()
        {
            Item item = CreateAppreciatingItemWithVariableQualityRate(15, 20);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(14, item.SellIn);
            Assert.Equal(21, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_AppreciatingItem_VariableQualityRate_Tier2()
        {
            Item item = CreateAppreciatingItemWithVariableQualityRate(9, 20);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(8, item.SellIn);
            Assert.Equal(22, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_AppreciatingItem_VariableQualityRate_Tier3()
        {
            Item item = CreateAppreciatingItemWithVariableQualityRate(2, 20);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(1, item.SellIn);
            Assert.Equal(23, item.Quality);
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
