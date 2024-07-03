using GildedRose.Console;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        [Fact]
        public void TestTheTruth()
        {
            Assert.True(true);
        }

        [Fact]
        public void UpdateQualityShouldNotThrowException()
        {
            var app = new Program()
            {
                Items = new List<Item>()
            };
            app.UpdateQuality();
            Assert.True(true);
        }

        [Theory]
        [InlineData(18, 20)]
        public void TestItem_Conjured(int expectedQuality, int sellIn)
        {
            // Arrange
            var app = new Program()
            {
                Items = new List<Item>
                {
                    new ConjuredItem(sellIn, 20)
                }
            };

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(expectedQuality, app.Items[0].Quality);
            Assert.Equal(sellIn - 1, app.Items[0].SellIn);
        }

        [Theory]
        [InlineData(21, 20)]
        [InlineData(22, 10)]
        [InlineData(23, 4)]
        [InlineData(0, 0)]
        public void TestItem_Backstage(int expectedQuality, int sellIn)
        {
            // Arrange
            var app = new Program()
            {
                Items = new List<Item>
                {
                    new BackstageItem(sellIn, 20)
                }
            };

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(expectedQuality, app.Items[0].Quality);
            Assert.Equal(sellIn - 1, app.Items[0].SellIn);
        }

        [Theory]
        [InlineData(21, 4)]
        [InlineData(22, 0)]
        public void TestItem_AgedBrie(int expectedQuality, int sellIn)
        {
            // Arrange
            var app = new Program()
            {
                Items = new List<Item>
                {
                    new AgedBrieItem(sellIn, 20)
                }
            };

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(expectedQuality, app.Items[0].Quality);
            Assert.Equal(sellIn - 1, app.Items[0].SellIn);
        }

        [Theory]
        [InlineData(20, 20)]
        [InlineData(20, -1)]
        public void TestItem_Sulfuras(int expectedQuality, int sellIn)
        {
            // Arrange
            var app = new Program()
            {
                Items = new List<Item>
                {
                    new SulfurasItem(sellIn, 20)
                }
            };

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(expectedQuality, app.Items[0].Quality);
            Assert.Equal(sellIn, app.Items[0].SellIn);
        }

        [Theory]
        [InlineData(19, 20)]
        [InlineData(18, 0)]
        public void TestItem_NormalItem(int expectedQuality, int sellIn)
        {
            // Arrange
            var app = new Program()
            {
                Items = new List<Item>
                {
                    new Item
                    {
                        Name = "Normal Item",
                        SellIn = sellIn,
                        Quality = 20
                    }
                }
            };

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(expectedQuality, app.Items[0].Quality);
            Assert.Equal(sellIn - 1, app.Items[0].SellIn);
        }
    }
}