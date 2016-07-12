using GildedRose.Console;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
    /// <summary>
    /// Initial set of unit tests to cover functionality as it stands before we change anything.
    /// </summary>
    public class ProgramTests
    {
        private Item GetStandardItem(int sellIn, int quality)
        {
            Item item = new Item { Name = "+5 Dexterity Vest", SellIn = sellIn, Quality = quality };
            return item;
        }

        private Item GetAppreciatingItem(int sellIn, int quality)
        {
            Item item = new Item { Name = "Aged Brie", SellIn = sellIn, Quality = quality };
            return item;
        }

        private Item GetAppreciatingItemWithVariableQualityRate(int sellIn, int quality)
        {
            Item item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality };
            return item;
        }

        private Item GetFixedQualityItem(int sellIn, int quality)
        {
            Item item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = sellIn, Quality = quality };
            return item;
        }

        [Fact]
        public void UpdateQualityTest_StandardItem()
        {
            Item item = GetStandardItem(10, 20);

            Program program = new Program();
            program.Items = new List<Item>() { item };
            program.UpdateQuality();

            Assert.Equal(9, item.SellIn);
            Assert.Equal(19, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_StandardItem_PastSellByDate()
        {
            Item item = GetStandardItem(-1, 20);

            Program program = new Program();
            program.Items = new List<Item>() { item };
            program.UpdateQuality();

            Assert.Equal(-2, item.SellIn);
            Assert.Equal(18, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_StandardItem_PastSellByDate_NoQualityRemaining()
        {
            Item item = GetStandardItem(-1, 0);

            Program program = new Program();
            program.Items = new List<Item>() { item };
            program.UpdateQuality();

            Assert.Equal(-2, item.SellIn);
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_AppreciatingItem()
        {
            Item item = GetAppreciatingItem(2, 0);

            Program program = new Program();
            program.Items = new List<Item>() { item };
            program.UpdateQuality();

            Assert.Equal(1, item.SellIn);
            Assert.Equal(1, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_AppreciatingItem_MaxQuality()
        {
            Item item = GetAppreciatingItem(2, 50);

            Program program = new Program();
            program.Items = new List<Item>() { item };
            program.UpdateQuality();

            Assert.Equal(1, item.SellIn);
            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_AppreciatingItem_VariableQualityRate_Tier1()
        {
            Item item = GetAppreciatingItemWithVariableQualityRate(15, 20);

            Program program = new Program();
            program.Items = new List<Item>() { item };
            program.UpdateQuality();

            Assert.Equal(14, item.SellIn);
            Assert.Equal(21, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_AppreciatingItem_VariableQualityRate_Tier2()
        {
            Item item = GetAppreciatingItemWithVariableQualityRate(9, 20);

            Program program = new Program();
            program.Items = new List<Item>() { item };
            program.UpdateQuality();

            Assert.Equal(8, item.SellIn);
            Assert.Equal(22, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_AppreciatingItem_VariableQualityRate_Tier3()
        {
            Item item = GetAppreciatingItemWithVariableQualityRate(2, 20);

            Program program = new Program();
            program.Items = new List<Item>() { item };
            program.UpdateQuality();

            Assert.Equal(1, item.SellIn);
            Assert.Equal(23, item.Quality);
        }

        [Fact]
        public void UpdateQualityTest_FixedQualityItem()
        {
            Item item = GetFixedQualityItem(0, 80);

            Program program = new Program();
            program.Items = new List<Item>() { item };
            program.UpdateQuality();

            Assert.Equal(0, item.SellIn);
            Assert.Equal(80, item.Quality);
        }
    }
}
