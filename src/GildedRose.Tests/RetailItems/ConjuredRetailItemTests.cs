using GildedRose.Console;
using GildedRose.Console.RetailItems;
using Xunit;

namespace GildedRose.Tests.RetailItems
{
    public class ConjuredRetailItemTests { 

        [Fact]
        public void UpdateQuality_ItemSellinAboveZero_ReducesQualityTwiceAsFast()
        {
            var item1 = new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 };
            var item2 = new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 };

            var standardRetailItem = new StandardRetailItem(item1);
            var conjuredRetailItem = new ConjuredRetailItem(item2);

            standardRetailItem.UpdateQuality();
            conjuredRetailItem.UpdateQuality();

            var diff1 = 20 - item1.Quality;
            var diff2 = 20 - item2.Quality;
               
            var rateComparison = diff2 / diff1;

            Assert.Equal(item1.SellIn, item2.SellIn);
            Assert.Equal(2, rateComparison);
        }

        [Fact]
        public void UpdateQuality_ItemSellinBelowZero_ReducesQualityTwiceAsFast()
        {
            var item1 = new Item { Name = "+5 Dexterity Vest", SellIn = -1, Quality = 20 };
            var item2 = new Item { Name = "+5 Dexterity Vest", SellIn = -1, Quality = 20 };

            var standardRetailItem = new StandardRetailItem(item1);
            var conjuredRetailItem = new ConjuredRetailItem(item2);

            standardRetailItem.UpdateQuality();
            conjuredRetailItem.UpdateQuality();

            var diff1 = 20 - item1.Quality;
            var diff2 = 20 - item2.Quality;

            var rateComparison = diff2 / diff1;

            Assert.Equal(item1.SellIn, item2.SellIn);
            Assert.Equal(2, rateComparison);
        }

    }
}
