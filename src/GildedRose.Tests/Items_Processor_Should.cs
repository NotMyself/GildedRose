using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using FluentAssertions;
using GildedRose.Console;
using Xunit;
using Xunit.Sdk;

namespace GildedRose.Tests
{
    public class ItemsProcessorShould
    {
        [Theory]
        [InlineData("+5 Dexterity Vest", 10, 9, 20, 19)]
        [InlineData("Aged Brie", 2, 1, 0, 1)]
        [InlineData("Elixir of the Mongoose", 5, 4, 7, 6)]
        [InlineData("Sulfuras, Hand of Ragnaros", 0, 0, 80, 80)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 15, 14, 20, 21)]
        [InlineData("Conjured Mana Cake", 3, 2, 6, 5)]
        public void Ensure_Backwards_Compatability_For_The_Items(string itemName, int sellInInput, int sellInExpected, int qualityInput, int qualityExpected)
        {
            //Arrange
            var expected = new Item() {Name = itemName, SellIn = sellInExpected, Quality = qualityExpected};

            var input = new List<Item>
            {
                new Item {Name = itemName, SellIn = sellInInput, Quality = qualityInput}
            };

            //Act
            var sut = new ItemsProcessor(input);

            sut.UpdateQuality();

            //Assert
            sut.Items.Single().ShouldBeEquivalentTo(expected);
        }
    }
}
