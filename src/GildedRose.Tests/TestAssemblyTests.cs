using Xunit;
using GildedRose.Console;
using System.Collections.Generic;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        [Fact]
        public void UpdateQuality_SellByDateHasNotPassed_ReducesValues()
        {
            // Arrange
            var item = new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 };
            var items = new List<Item> { item };
            var p = new Program();
            
            // Act
            p.UpdateQuality(items);

            //Assert
            Assert.Equal(9, item.SellIn);
            Assert.Equal(19, item.Quality);
        }

        [Fact]
        public void UpdateQuality_SellByDatePassed_QualityDegradesTwiceAsFast()
        {
            // Arrange
            var item = new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 20 };
            var items = new List<Item> { item };
            var p = new Program();

            // Act
            p.UpdateQuality(items);

            //Assert
            Assert.Equal(-1, item.SellIn);
            Assert.Equal(18, item.Quality);
        }

        [Fact]
        public void UpdateQuality_AgedBrie_IncreasesInQuality()
        {
            // Arrange
            var item = new Item { Name = "Aged Brie", SellIn = 1, Quality = 20 };
            var items = new List<Item> { item };
            var p = new Program();

            // Act
            p.UpdateQuality(items);

            //Assert
            Assert.Equal(0, item.SellIn);
            Assert.Equal(21, item.Quality);
        }

        [Fact]
        public void UpdateQuality_AgedBrie_IncreasesInQualityTwice()
        {
            // Arrange
            var item = new Item { Name = "Aged Brie", SellIn = 0, Quality = 20 };
            var items = new List<Item> { item };
            var p = new Program();

            // Act
            p.UpdateQuality(items);

            //Assert
            Assert.Equal(-1, item.SellIn);
            Assert.Equal(22, item.Quality);
        }


        [Fact]
        public void UpdateQuality_ItemAlready50_DoesNotExceed50()
        {
            // Arrange
            var item = new Item { Name = "Aged Brie", SellIn = 0, Quality = 50 };
            var items = new List<Item> { item };
            var p = new Program();

            // Act
            p.UpdateQuality(items);

            //Assert
            Assert.Equal(-1, item.SellIn);
            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void UpdateQuality_Sulfuras_ValuesNeverChange()
        {
            // Arrange
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 };
            var items = new List<Item> { item };
            var p = new Program();

            // Act
            p.UpdateQuality(items);

            //Assert
            Assert.Equal(10, item.SellIn);
            Assert.Equal(80, item.Quality);
        }

        [Theory]
        [InlineData(11, 2, 10, 3)]
        [InlineData(10, 2, 9, 4)]
        [InlineData(5, 2, 4, 5)]
        [InlineData(0, 2, -1, 0)]
        public void UpdateQuality_BackstagesPasses_UpdatesCorrectValues(int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            // Arrange
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality };
            var items = new List<Item> { item };
            var p = new Program();

            // Act
            p.UpdateQuality(items);

            //Assert
            Assert.Equal(expectedSellIn, item.SellIn);
            Assert.Equal(expectedQuality, item.Quality);
        }
    }
}