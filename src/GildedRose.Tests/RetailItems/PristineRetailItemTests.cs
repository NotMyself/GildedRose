using GildedRose.Console;
using GildedRose.Console.RetailItems;
using Xunit;

namespace GildedRose.Tests.RetailItems
{
    public class PristineRetailItemTests
    {
        [Fact]
        public void UpdateQuality_Sulfuras_ValuesNeverChange()
        {
            // Arrange
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 };
            var pristineRetailItem = new PristineRetailItem(item);
            
            // Act
            pristineRetailItem.UpdateQuality();

            //Assert
            Assert.Equal(10, item.SellIn);
            Assert.Equal(80, item.Quality);
        }
    }
}
