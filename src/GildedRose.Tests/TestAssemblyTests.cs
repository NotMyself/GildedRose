using System.Collections.Generic;
using System.Linq;
using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
            private Item _dexterityVest = new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20};
            private Item _agedBrie = new Item {Name = "Aged Brie", SellIn = 2, Quality = 0};
            private Item _elexirOfMongoose = new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7};
            private Item _sulfuras = new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80};
            private Item _backstagePass = new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20};
            private Item _manaCake = new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6};
        
        
        [Fact]
        public void Normal_item_reduces_in_quality_and_sell_in_by_1_on_update_quality()
        {
            var sellIn = 10;
            var quality = 20;
            var item = GetItem(sellIn, quality);

            var returnedItem = Program.UpdateQuality(new List<Item>() {item}).Single();
            
            Assert.Equal(9, returnedItem.SellIn);
            Assert.Equal(19, returnedItem.Quality);
        }

        [Fact]
        public void Quality_on_normal_item_degrades_by_two_when_sell_in_is_less_than_zero()
        {
            var sellIn = -1;
            var quality = 20;
            var item = GetItem(sellIn, quality);

            var returnedItem = Program.UpdateQuality(new List<Item>() {item}).Single();
            
            Assert.Equal(-2, returnedItem.SellIn);
            Assert.Equal(18, returnedItem.Quality);
        }

        [Fact]
        public void Quality_reduces_by_two_when_sell_in_is_zero()
        {
            var sellIn = 0;
            var quality = 20;
            var item = GetItem(sellIn, quality);

            var returnedItem = Program.UpdateQuality(new List<Item>() {item}).Single();
            
            Assert.Equal(-1, returnedItem.SellIn);
            Assert.Equal(18, returnedItem.Quality);
        }

        [Fact]
        public void Quality_reduces_by_one_when_sell_in_is_one()
        {
            var sellIn = 1;
            var quality = 20;
            var item = GetItem(sellIn, quality);

            var returnedItem = Program.UpdateQuality(new List<Item>() {item}).Single();
            
            Assert.Equal(0, returnedItem.SellIn);
            Assert.Equal(19, returnedItem.Quality);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        [InlineData(-1)]
        public void Quality_on_a_normal_item_does_not_drop_below_zero(int sellIn)
        {
            var quality = 0;
            var item = GetItem(sellIn, quality);

            var returnedItem = Program.UpdateQuality(new List<Item>() {item}).Single();
            
            Assert.Equal(sellIn - 1, returnedItem.SellIn);
            Assert.Equal(0, returnedItem.Quality);
        }

        [Fact]
        public void Aged_brie_increases_quality_by_one_when_sell_in_greater_than_zero()
        {
            var quality = 20;
            var sellIn = 1;
            
            var item = GetAgedBrie(sellIn, quality);
            
            var returnedItem = Program.UpdateQuality(new List<Item>() {item}).Single();
            
            Assert.Equal(21, returnedItem.Quality);
            Assert.Equal(0, returnedItem.SellIn);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Aged_brie_increases_in_quality_by_two_when_sell_in_is_less_than_one(int sellIn)
        {
            var quality = 20;
            
            var item = GetAgedBrie(sellIn, quality);
            
            var returnedItem = Program.UpdateQuality(new List<Item>() {item}).Single();
            
            Assert.Equal(22, returnedItem.Quality);
            Assert.Equal(sellIn - 1, returnedItem.SellIn);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(1)]
        public void Aged_brie_cannot_have_a_quality_of_more_than_50(int sellIn)
        {
            var quality = 49;
            
            var item = GetAgedBrie(sellIn, quality);
            
            var returnedItem = Program.UpdateQuality(new List<Item>() {item}).Single();
            
            Assert.Equal(50, returnedItem.Quality);
            Assert.Equal(sellIn - 1, returnedItem.SellIn);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        [InlineData(-1)]
        public void Legendary_items_never_decrease_in_quality_or_sell_in(int sellIn)
        {
            var quality = 20;

            var item = GetLegendaryItem(sellIn, quality);
            
            var returnedItem = Program.UpdateQuality(new List<Item>() {item}).Single();
            
            Assert.Equal(quality, returnedItem.Quality);
            Assert.Equal(sellIn, returnedItem.SellIn);
        }

        [Fact]
        public void Backstage_passes_increase_quality_by_1_when_sell_in_greater_than_10()
        {
            var quality = 20;
            var sellIn = 11;
            
            var item = GetBackstagePass(sellIn, quality);
            
            var returnedItem = Program.UpdateQuality(new List<Item>() {item}).Single();
            
            Assert.Equal(21, returnedItem.Quality);
            Assert.Equal(10, returnedItem.SellIn);
        }

        [Theory]
        [InlineData(6)]
        [InlineData(8)]
        [InlineData(10)]
        public void Backstage_passes_increase_quality_by_2_when_there_sell_in_is_between_6_and_10(int sellIn)
        {
            var quality = 20;
            
            var item = GetBackstagePass(sellIn, quality);
            
            var returnedItem = Program.UpdateQuality(new List<Item>() {item}).Single();
            
            Assert.Equal(22, returnedItem.Quality);
            Assert.Equal(sellIn - 1, returnedItem.SellIn);
        }
        
        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        public void Backstage_passes_increase_quality_by_3_when_there_sell_in_is_between_1_and_5(int sellIn)
        {
            var quality = 20;
            
            var item = GetBackstagePass(sellIn, quality);
            
            var returnedItem = Program.UpdateQuality(new List<Item>() {item}).Single();
            
            Assert.Equal(23, returnedItem.Quality);
            Assert.Equal(sellIn - 1, returnedItem.SellIn);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Backstage_passes_have_their_quality_set_to_zero_when_sell_in_is_zero_or_less(int sellIn)
        {
            var quality = 20;
            
            var item = GetBackstagePass(sellIn, quality);
            
            var returnedItem = Program.UpdateQuality(new List<Item>() {item}).Single();
            
            Assert.Equal(0, returnedItem.Quality);
            Assert.Equal(sellIn - 1, returnedItem.SellIn);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(9)]
        [InlineData(12)]
        public void Backstage_passes_quality_cannot_go_over_50(int sellIn)
        {
            var quality = 49;
            
            var item = GetBackstagePass(sellIn, quality);
            
            var returnedItem = Program.UpdateQuality(new List<Item>() {item}).Single();
            
            Assert.Equal(50, returnedItem.Quality);
            Assert.Equal(sellIn - 1, returnedItem.SellIn);
        }

        private Item GetItem(int sellIn, int quality, string name = "item 1")
        {
            return new Item(){Name = name, SellIn =  sellIn, Quality = quality};
        }

        private Item GetAgedBrie(int sellIn, int quality)
        {
            return GetItem(sellIn, quality, "Aged Brie");
        }

        private Item GetBackstagePass(int sellIn, int quality)
        {
            return GetItem(sellIn, quality, "Backstage passes to a TAFKAL80ETC concert");
        }

        private Item GetLegendaryItem(int sellIn, int quality)
        {
            return GetItem(sellIn, quality, "Sulfuras, Hand of Ragnaros");
        }
    }
}