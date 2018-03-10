using GildedRose.Console;
using GildedRose.Console.RetailItems;
using Xunit;

namespace GildedRose.Tests.RetailItems
{
    public class AgedRetailItemTests
    {
        [Fact]
        public void UpdateQuality_AgedBrie_IncreasesInQuality()
        {
            // Arrange
            var item = new Item { Name = "Aged Brie", SellIn = 1, Quality = 20 };
            var retailItem = new AgedRetailItem(item);

            // Act
            retailItem.UpdateQuality();

            //Assert
            Assert.Equal(0, item.SellIn);
            Assert.Equal(21, item.Quality);
        }

        [Fact]
        public void UpdateQuality_AgedBrie_IncreasesInQualityTwice()
        {
            // Arrange
            var item = new Item { Name = "Aged Brie", SellIn = 0, Quality = 20 };
            var retailItem = new AgedRetailItem(item);

            // Act
            retailItem.UpdateQuality();

            //Assert
            Assert.Equal(-1, item.SellIn);
            Assert.Equal(22, item.Quality);
        }

    }
}
