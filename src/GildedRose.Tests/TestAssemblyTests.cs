using Xunit;
using GildedRose.Console;
using System.Collections.Generic;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        private Program createAppWithTestData(List<Item> testData)
        {
            Program app = new Program();
            app.Items = testData;
            return app;
        }
        [Fact]
        public void ItemGeneral_WithinSellInPeriod_ValuesAdjustedByOne()
        {
            List<Item> testData = new List<Item> {
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
            Program app = createAppWithTestData(testData);

            // Update the application's quality and verify the values.
            app.UpdateQuality();


            Item dex_vest = app.Items[0];
        
            Assert.Equal(dex_vest.Name, "+5 Dexterity Vest");
            Assert.Equal(dex_vest.SellIn, 9);
            Assert.Equal(dex_vest.Quality, 19);
        }
        [Fact]
        public void ItemGeneral_PastSellinTimePeriod_QualityDegradesByTwoPoints()
        {
            List<Item> testData = new List<Item> {
                new Item {Name = "+5 Dexterity Vest", SellIn = 0, Quality = 20}
            };
            Program app = createAppWithTestData(testData);

            app.UpdateQuality();

            Item dex_vest = app.Items[0];
            Assert.Equal(dex_vest.Name, "+5 Dexterity Vest");
            Assert.Equal(dex_vest.SellIn, -1);
            Assert.Equal(dex_vest.Quality, 18);
        }
        [Fact]
        public void ItemAll_PastQualityDegradationMax_QualityIsNeverNegative()
        {
            List<Item> testData = new List<Item> {
                new Item {Name = "+5 Dexterity Vest", SellIn = -4, Quality = 2}
            };
            Program app = createAppWithTestData(testData);

            // The quality can be zero
            app.UpdateQuality();
            Item dex_vest = app.Items[0];
            Assert.Equal(dex_vest.Name, "+5 Dexterity Vest");
            Assert.Equal(dex_vest.SellIn, -5);
            Assert.Equal(dex_vest.Quality, 0);

            // The quality does not go below zero
            app.UpdateQuality();
            Assert.Equal(dex_vest.Name, "+5 Dexterity Vest");
            Assert.Equal(dex_vest.SellIn, -6);
            Assert.Equal(dex_vest.Quality, 0);
        }
        [Fact]
        public void ItemBrieCheese_DecreaseSellin_QualityIncreases()
        {
            List<Item> testData = new List<Item> {
                new Item {Name = "Aged Brie", SellIn = 10, Quality = 20}
            };
            Program app = createAppWithTestData(testData);

            app.UpdateQuality();
            Item brie_cheese = app.Items[0];
            Assert.Equal(brie_cheese.Name, "Aged Brie");
            Assert.Equal(brie_cheese.SellIn, 9);
            Assert.Equal(brie_cheese.Quality, 21);
        }
        [Fact]
        public void ItemLegendarySulfuras_SellinDecreases_QualityRemains80()
        {
            List<Item> testData = new List<Item> {
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 2, Quality = 80}
            };
            Program app = createAppWithTestData(testData);
            
            // The quality can be zero.
            app.UpdateQuality();
            Item sulfuras_item = app.Items[0];
            Assert.Equal(sulfuras_item.Name, "Sulfuras, Hand of Ragnaros");
            Assert.Equal(sulfuras_item.SellIn, 2);
            Assert.Equal(sulfuras_item.Quality, 80);

            // Verify that Sulfuras Sellin does not go below.
            app.UpdateQuality();
            app.UpdateQuality();
            Assert.Equal(sulfuras_item.Name, "Sulfuras, Hand of Ragnaros");
            Assert.Equal(sulfuras_item.SellIn, 2);
            Assert.Equal(sulfuras_item.Quality, 80);

        }

        [Fact]
        public void ItemWithIncreasingQuality_QualityIncreases_QualityNeverExceedsMaxValue50()
        {
            List<Item> testData = new List<Item> {
                new Item {Name = "Aged Brie", SellIn = 10, Quality = 49}
            };
            Program app = createAppWithTestData(testData);

            // The quality increases to 50 with items such as brie.
            app.UpdateQuality();
            Item brie_cheese = app.Items[0];
            Assert.Equal(brie_cheese.Name, "Aged Brie");
            Assert.Equal(brie_cheese.SellIn, 9);
            Assert.Equal(brie_cheese.Quality, 50);

            // The quality does not exceed 50.
            app.UpdateQuality();
            Assert.Equal(brie_cheese.Name, "Aged Brie");
            Assert.Equal(brie_cheese.SellIn, 8);
            Assert.Equal(brie_cheese.Quality, 50);
        }
        [Fact]
        public void ItemBackStagePass_SellinGreaterThan10_QualityIncreasesByOne()
        {
            List<Item> testData = new List<Item> {
                new Item 
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                }
            };
            Program app = createAppWithTestData(testData);
            app.UpdateQuality();
            Item backstage_pass = app.Items[0];
            Assert.Equal(backstage_pass.Name, "Backstage passes to a TAFKAL80ETC concert");
            Assert.Equal(backstage_pass.SellIn, 14);
            Assert.Equal(backstage_pass.Quality, 21);

        }
        [Fact]
        public void ItemBackStagePass_SellinLessThan10_QualityIncreasesByTwo()
        {
            List<Item> testData = new List<Item> {
                new Item 
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 22
                }
            };
            Program app = createAppWithTestData(testData);
            app.UpdateQuality();
            Item backstage_pass = app.Items[0];
            Assert.Equal(backstage_pass.Name, "Backstage passes to a TAFKAL80ETC concert");
            Assert.Equal(backstage_pass.SellIn, 9);
            Assert.Equal(backstage_pass.Quality, 24);

        }
        [Fact]
        public void ItemBackStagePass_SellinGreaterThan5_QualityIncreasesByThree()
        {
            List<Item> testData = new List<Item> {
                new Item 
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 24
                }
            };
            Program app = createAppWithTestData(testData);
            app.UpdateQuality();
            Item backstage_pass = app.Items[0];
            Assert.Equal(backstage_pass.Name, "Backstage passes to a TAFKAL80ETC concert");
            Assert.Equal(backstage_pass.SellIn, 4);
            Assert.Equal(backstage_pass.Quality, 27);
        }
    }

}