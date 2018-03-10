using GildedRose.Console;
using GildedRose.Console.RetailItems;
using Xunit;

namespace GildedRose.Tests.RetailItems
{
    public class ScalpingRetailItemTestscs
    {
        [Theory]
        [InlineData(11, 2, 10, 3)]
        [InlineData(10, 2, 9, 4)]
        [InlineData(5, 2, 4, 5)]
        [InlineData(0, 2, -1, 0)]
        public void UpdateQuality_BackstagesPasses_UpdatesCorrectValues(int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            // Arrange
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality };
            var scalpingRetailItem = new ScalpingRetailItem(item);

            // Act
            scalpingRetailItem.UpdateQuality();

            //Assert
            Assert.Equal(expectedSellIn, item.SellIn);
            Assert.Equal(expectedQuality, item.Quality);
        }
    }
}
