using Xunit;
using GildedRose.Console;
using System.Collections.Generic;

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
        public void UpdateQualityForGivenScenario()
        {
            IList<Item> Items = new List<Item>
                {
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                    new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                    new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                    new Item
                        {
                            Name = "Backstage passes to a TAFKAL80ETC concert",
                            SellIn = 15,
                            Quality = 20
                        },
                    new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                };

            Items = Program.UpdateQuality(Items);

            Assert.Equal(9, Items[0].SellIn);
            Assert.Equal(19, Items[0].Quality);

            Assert.Equal(1, Items[1].SellIn);
            Assert.Equal(1, Items[1].Quality);

            Assert.Equal(4, Items[2].SellIn);
            Assert.Equal(6, Items[2].Quality);

            Assert.Equal(0, Items[3].SellIn);
            Assert.Equal(80, Items[3].Quality);

            Assert.Equal(14, Items[4].SellIn);
            Assert.Equal(21, Items[4].Quality);

            Assert.Equal(2, Items[5].SellIn);
            Assert.Equal(5, Items[5].Quality);

        }

        [Fact]
        public void QualityDegradationAfterSellByDate()
        {
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 0, Quality = 10 },
                new Item {Name = "Aged Brie", SellIn = 0, Quality = 10 },
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Item
                        {
                            Name = "Backstage passes to a TAFKAL80ETC concert",
                            SellIn = 0,
                            Quality = 20
                        }
            };

            Items = Program.UpdateQuality(Items);

            // Normal item should degrade by 2
            Assert.Equal(-1, Items[0].SellIn);
            Assert.Equal(8, Items[0].Quality);

            // Aged Brie should increase by 2
            Assert.Equal(-1, Items[1].SellIn);
            Assert.Equal(12, Items[1].Quality);

            // Sulfuras quality and sell by is unchanged
            Assert.Equal(0, Items[2].SellIn);
            Assert.Equal(80, Items[2].Quality);

            // Backstage passes quality should be 0
            Assert.Equal(-1, Items[3].SellIn);
            Assert.Equal(0, Items[3].Quality);
        }
    }
}