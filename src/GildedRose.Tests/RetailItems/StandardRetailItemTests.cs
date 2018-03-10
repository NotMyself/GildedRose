using GildedRose.Console;
using GildedRose.Console.RetailItems;
using Xunit;

namespace GildedRose.Tests.RetailItems
{
    public class StandardRetailItemTests
    {
        [Fact]
        public void UpdateQuality_SellByDateHasNotPassed_ReducesValues()
        {
            // Arrange
            var item = new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 };
            var standardRetailItem = new StandardRetailItem(item);

            // Act
            standardRetailItem.UpdateQuality();

            //Assert
            Assert.Equal(9, item.SellIn);
            Assert.Equal(19, item.Quality);
        }

        [Fact]
        public void UpdateQuality_SellByDatePassed_QualityDegradesTwiceAsFast()
        {
            // Arrange
            var item = new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 20 };
            var standardRetailItem = new StandardRetailItem(item);

            // Act
            standardRetailItem.UpdateQuality();

            //Assert
            Assert.Equal(-1, item.SellIn);
            Assert.Equal(18, item.Quality);
        }
    }
}
