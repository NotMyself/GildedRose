using System.Collections.Generic;
using Xunit;

// Avoid the namespace/type collision with aliases.
using App = global::GildedRose.Console.GildedRose;
using AppItem = global::GildedRose.Console.Item;

namespace GildedRose.Tests
{
    public class GildedRoseRulesTests
    {
        // Helpers
        private static AppItem Make(string name, int sellIn, int quality) =>
            new AppItem { Name = name, SellIn = sellIn, Quality = quality };

        private static void AdvanceDays(App app, int days)
        {
            for (int i = 0; i < days; i++) app.UpdateQuality();
        }

        // Normal items
        [Fact]
        public void NormalItem_DegradesBy1_PerDay_BeforeSellDate()
        {
            var items = new List<AppItem> { Make("+5 Dexterity Vest", 10, 20) };
            var app = new App(items);

            AdvanceDays(app, 1);

            Assert.Equal(9, items[0].SellIn);
            Assert.Equal(19, items[0].Quality);
        }

        [Fact]
        public void NormalItem_DegradesBy2_PerDay_AfterSellDate()
        {
            var items = new List<AppItem> { Make("Elixir of the Mongoose", 0, 7) };
            var app = new App(items);

            AdvanceDays(app, 1);

            Assert.Equal(-1, items[0].SellIn);
            Assert.Equal(5, items[0].Quality);
        }

        [Fact]
        public void NormalItem_QualityNeverNegative()
        {
            var items = new List<AppItem> { Make("Elixir of the Mongoose", 5, 0) };
            var app = new App(items);

            AdvanceDays(app, 3);

            Assert.Equal(2, items[0].SellIn);
            Assert.Equal(0, items[0].Quality);
        }

        // Aged Brie
        [Fact]
        public void AgedBrie_IncreasesBy1_PerDay_BeforeSellDate()
        {
            var items = new List<AppItem> { Make("Aged Brie", 5, 10) };
            var app = new App(items);

            AdvanceDays(app, 1);

            Assert.Equal(4, items[0].SellIn);
            Assert.Equal(11, items[0].Quality);
        }

        [Fact]
        public void AgedBrie_IncreasesBy2_PerDay_AfterSellDate()
        {
            var items = new List<AppItem> { Make("Aged Brie", 0, 10) };
            var app = new App(items);

            AdvanceDays(app, 1);

            Assert.Equal(-1, items[0].SellIn);
            Assert.Equal(12, items[0].Quality);
        }

        [Fact]
        public void AgedBrie_QualityCappedAt50()
        {
            var items = new List<AppItem> { Make("Aged Brie", 3, 49) };
            var app = new App(items);

            AdvanceDays(app, 3);

            Assert.Equal(0, items[0].SellIn);
            Assert.Equal(50, items[0].Quality);
        }

        // Sulfuras
        [Fact]
        public void Sulfuras_NeverChanges()
        {
            var items = new List<AppItem> { Make("Sulfuras, Hand of Ragnaros", 5, 80) };
            var app = new App(items);

            AdvanceDays(app, 5);

            Assert.Equal(5, items[0].SellIn);
            Assert.Equal(80, items[0].Quality);
        }

        // Backstage passes
        [Fact]
        public void Backstage_Plus1_WhenMoreThan10Days()
        {
            var items = new List<AppItem> { Make("Backstage passes to a TAFKAL80ETC concert", 15, 20) };
            var app = new App(items);

            AdvanceDays(app, 1);

            Assert.Equal(14, items[0].SellIn);
            Assert.Equal(21, items[0].Quality);
        }

        [Fact]
        public void Backstage_Plus2_When10To6Days()
        {
            var items = new List<AppItem> { Make("Backstage passes to a TAFKAL80ETC concert", 10, 20) };
            var app = new App(items);

            AdvanceDays(app, 1);

            Assert.Equal(9, items[0].SellIn);
            Assert.Equal(22, items[0].Quality);
        }

        [Fact]
        public void Backstage_Plus3_When5To0Days()
        {
            var items = new List<AppItem> { Make("Backstage passes to a TAFKAL80ETC concert", 5, 20) };
            var app = new App(items);

            AdvanceDays(app, 1);

            Assert.Equal(4, items[0].SellIn);
            Assert.Equal(23, items[0].Quality);
        }

        [Fact]
        public void Backstage_DropsToZero_AfterConcert()
        {
            var items = new List<AppItem> { Make("Backstage passes to a TAFKAL80ETC concert", 0, 30) };
            var app = new App(items);

            AdvanceDays(app, 1);

            Assert.Equal(-1, items[0].SellIn);
            Assert.Equal(0, items[0].Quality);
        }

        // Conjured
        [Fact]
        public void Conjured_DegradesTwiceAsFast_BeforeSellDate()
        {
            var items = new List<AppItem> { Make("Conjured Mana Cake", 3, 10) };
            var app = new App(items);

            AdvanceDays(app, 1);

            Assert.Equal(2, items[0].SellIn);
            Assert.Equal(8, items[0].Quality);
        }

        [Fact]
        public void Conjured_DegradesFourPerDay_AfterSellDate()
        {
            var items = new List<AppItem> { Make("Conjured Mana Cake", 0, 10) };
            var app = new App(items);

            AdvanceDays(app, 1);

            Assert.Equal(-1, items[0].SellIn);
            Assert.Equal(6, items[0].Quality);
        }

        [Fact]
        public void Conjured_QualityNeverNegative()
        {
            var items = new List<AppItem> { Make("Conjured Mana Cake", 0, 3) };
            var app = new App(items);

            AdvanceDays(app, 2);

            Assert.Equal(-2, items[0].SellIn);
            Assert.Equal(0, items[0].Quality);
        }

        // Global invariant
        [Fact]
        public void QualityNeverAbove50_ForNonLegendary()
        {
            var items = new List<AppItem>
            {
                Make("Aged Brie", 2, 50),
                Make("Backstage passes to a TAFKAL80ETC concert", 6, 50)
            };
            var app = new App(items);

            AdvanceDays(app, 2);

            Assert.Equal(50, items[0].Quality);
            Assert.Equal(50, items[1].Quality);
        }
    }
}
