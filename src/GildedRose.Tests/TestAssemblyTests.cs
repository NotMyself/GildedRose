using Xunit;
using GildedRose.Console;
using System.Collections.Generic;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
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
    }
}