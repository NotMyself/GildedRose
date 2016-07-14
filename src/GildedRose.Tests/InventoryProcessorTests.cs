using GildedRose.Inventory.Domain.Entities;
using GildedRose.Inventory.Domain.Logic;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
    /// <summary>
    /// Unit tests to cover the InventoryProcessor class.
    /// </summary>
    public class InventoryProcessorTests
    {
        public InventoryProcessorTests()
            : base()
        {
        }

        [Fact]
        public void UpdateQualityTest_DepreciatingItem_BeforeSellByDate()
        {
            Item item = InventoryTestUtility.CreateDepreciatingItem(10, 20);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });
            
            Assert.Equal(9, item.SellIn);
            Assert.Equal(19, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_DepreciatingItem_BeforeSellByDate_MinQualityReached()
        {
            Item item = InventoryTestUtility.CreateDepreciatingItem(6, 0);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(5, item.SellIn);
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_DepreciatingItem_AfterSellByDate()
        {
            Item item = InventoryTestUtility.CreateDepreciatingItem(-1, 20);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(-2, item.SellIn);
            Assert.Equal(18, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_DepreciatingItem_AfterSellByDate_MinQualityReached()
        {
            Item item = InventoryTestUtility.CreateDepreciatingItem(-1, 0);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(-2, item.SellIn);
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_DepreciatingItem_DoubleRate_BeforeSellByDate()
        {
            Item item = InventoryTestUtility.CreateDoubleRateDepreciatingItem(10, 20);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(9, item.SellIn);
            Assert.Equal(18, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_DepreciatingItem_DoubleRate_BeforeSellByDate_MinQualityReached()
        {
            Item item = InventoryTestUtility.CreateDoubleRateDepreciatingItem(6, 0);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(5, item.SellIn);
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_DepreciatingItem_DoubleRate_AfterSellByDate()
        {
            Item item = InventoryTestUtility.CreateDoubleRateDepreciatingItem(-1, 20);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(-2, item.SellIn);
            Assert.Equal(16, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_DepreciatingItem_DoubleRate_AfterSellByDate_MinQualityReached()
        {
            Item item = InventoryTestUtility.CreateDoubleRateDepreciatingItem(-1, 0);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(-2, item.SellIn);
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_AppreciatingItem_BeforeSellByDate()
        {
            Item item = InventoryTestUtility.CreateAppreciatingItem(2, 0);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(1, item.SellIn);
            Assert.Equal(1, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_AppreciatingItem_BeforeSellByDate_MaxQualityReached()
        {
            Item item = InventoryTestUtility.CreateAppreciatingItem(2, 50);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(1, item.SellIn);
            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_AppreciatingItem_AfterSellByDate()
        {
            Item item = InventoryTestUtility.CreateAppreciatingItem(-1, 0);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(-2, item.SellIn);
            Assert.Equal(2, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_AppreciatingItem_AfterSellByDate_MaxQualityReached()
        {
            Item item = InventoryTestUtility.CreateAppreciatingItem(-1, 50);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(-2, item.SellIn);
            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_AppreciatingItem_VariableQualityRate_BeforeSellByDate_Tier1()
        {
            Item item = InventoryTestUtility.CreateAppreciatingItemWithVariableQualityRate(15, 20);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(14, item.SellIn);
            Assert.Equal(21, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_AppreciatingItem_VariableQualityRate_BeforeSellByDate_Tier2()
        {
            Item item = InventoryTestUtility.CreateAppreciatingItemWithVariableQualityRate(9, 20);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(8, item.SellIn);
            Assert.Equal(22, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_AppreciatingItem_VariableQualityRate_BeforeSellByDate_Tier3()
        {
            Item item = InventoryTestUtility.CreateAppreciatingItemWithVariableQualityRate(2, 20);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(1, item.SellIn);
            Assert.Equal(23, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_AppreciatingItem_VariableQualityRate_AfterSellByDate()
        {
            Item item = InventoryTestUtility.CreateAppreciatingItemWithVariableQualityRate(-1, 20);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(-2, item.SellIn);
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_FixedQualityItem()
        {
            Item item = InventoryTestUtility.CreateFixedQualityItem(0, 80);

            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(new List<Item>() { item });

            Assert.Equal(0, item.SellIn);
            Assert.Equal(80, item.Quality);
        }
    }
}
