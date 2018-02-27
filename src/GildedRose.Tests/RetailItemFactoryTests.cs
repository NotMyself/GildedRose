using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class RetailItemFactoryTests
    {
        [Fact]
        public void CreateRetailItem_AgedBrie_ReturnsAgedRetailItem()
        {
            var item = new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 };

            var result = RetailItemFactory.CreateRetailItem(item);

            Assert.IsType<AgedRetailItem>(result);
        }

        [Fact]
        public void CreateRetailItem_BackstagePasses_ReturnsScalpingRetailItem()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 2, Quality = 0 };

            var result = RetailItemFactory.CreateRetailItem(item);

            Assert.IsType<ScalpingRetailItem>(result);
        }

        [Fact]
        public void CreateRetailItem_Sulfuras_ReturnsPristineRetailItem()
        {
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 2, Quality = 0 };

            var result = RetailItemFactory.CreateRetailItem(item);

            Assert.IsType<PristineRetailItem>(result);
        }

        [Fact]
        public void CreateRetailItem_NormalItem_ReturnsStandardRetalItem()
        {
            var item = new Item { Name = "Elixir of the Mongoose", SellIn = 2, Quality = 0 };

            var result = RetailItemFactory.CreateRetailItem(item);

            Assert.IsType<StandardRetailItem>(result);
        }

    }
}
