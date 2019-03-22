using Xunit;
using GildedRose.Console;
using System.Collections.Generic;

namespace GildedRose.Tests
{
    public class ProgramTests
    {
        #region Test Quality
        [Theory]
        [InlineData(1, 10, 11)]
        [InlineData(0, 50, 50)]
        [InlineData(-1, 0, 2)]
        [InlineData(-1, 48, 50)]
        [InlineData(-1, 49, 50)]
        [InlineData(-1, 50, 50)]
       // [InlineData(30, int.MaxValue, 50)]
       // [InlineData(int.MinValue, 2, 4)]
        public void UpdateQuality_AgedBrieQualityIsCorrect(int sellInActual, int qualityActual, int qualityExpected)
        {
            IList<RegularItem> actual = GetUpdatedItems<AgedBrie>(sellInActual, qualityActual, "Aged Brie");

            Assert.Equal(qualityExpected, actual[0].Quality);
        }

        [Theory]
        [InlineData(1, 10, 10)]
        [InlineData(0, 50, 50)]
        [InlineData(0, 80, 80)]
        [InlineData(-1, 0, 0)]
       // [InlineData(int.MinValue, 1, 1)]
        public void UpdateQuality_SulfurasQualityIsCorrect(int sellInActual, int qualityActual, int qualityExpected)
        {
            IList<RegularItem> actual = GetUpdatedItems<Sulfuras>(sellInActual, qualityActual, "Sulfuras, Hand of Ragnaros");

            Assert.Equal(qualityExpected, actual[0].Quality);
        }

        [Theory]
        [InlineData(6, 10, 12)]
        [InlineData(5, 10, 13)]
        [InlineData(10, 10, 12)]
        [InlineData(11, 10, 11)]
        [InlineData(0, 51, 0)]
        [InlineData(-1, 48, 0)]
        [InlineData(int.MaxValue, 48, 49)]
       // [InlineData(int.MinValue, 4, 0)]
        public void UpdateQuality_BackstagePassesQualityIsCorrect(int sellInActual, int qualityActual, int qualityExpected)
        {
            IList<RegularItem> actual = GetUpdatedItems<BackstagePass>(sellInActual, qualityActual, "Backstage passes to a TAFKAL80ETC concert");

            Assert.Equal(qualityExpected, actual[0].Quality);
        }

        [Theory]
        [InlineData(1, 10, 9)]
        [InlineData(0, 50, 48)]
        [InlineData(-1, 0, 0)]
        [InlineData(-1, 1, 0)]
       // [InlineData(int.MinValue, 4, 2)]
        public void UpdateQuality_RegularItemQualityIsCorrect(int sellInActual, int qualityActual, int qualityExpected)
        {
            IList<RegularItem> actual = GetUpdatedItems<RegularItem>(sellInActual, qualityActual, "Elixir of the Mongoose");

            Assert.Equal(qualityExpected, actual[0].Quality);
        }

        [Theory]
        [InlineData(1, 10, 8)]
        [InlineData(0, 10, 6)]
        [InlineData(1, 1, 0)]
        [InlineData(-1, 3, 0)]
        [InlineData(-1, 0, 0)]
       // [InlineData(int.MinValue, 3, 0)]
        public void UpdateQuality_ConjuredQualityIsCorrect(int sellInActual, int qualityActual, int qualityExpected)
        {
            IList<RegularItem> actual = GetUpdatedItems<Conjured>(sellInActual, qualityActual, "Conjured Mana Cake");

            Assert.Equal(qualityExpected, actual[0].Quality);
        }
        #endregion

        #region Test SellIn
        [Theory]
        [InlineData(1, 10, 1)]
        [InlineData(-1, 0, -1)]
        [InlineData(0, 48, 0)]
      //  [InlineData(int.MinValue, 80, int.MinValue)]
        public void UpdateQuality_SulfurasSellInIsCorrect(int sellInActual, int qualityActual, int sellInExpected)
        {
            IList<RegularItem> actual = GetUpdatedItems<Sulfuras>(sellInActual, qualityActual, "Sulfuras, Hand of Ragnaros");

            Assert.Equal(sellInExpected, actual[0].SellIn);
        }

        [Theory]
        [InlineData(1, 10, 0)]
        [InlineData(0, 10, -1)]
        [InlineData(-1, 0, -2)]
        public void UpdateQuality_AgedBrieSellInIsCorrect(int sellInActual, int qualityActual, int sellInExpected)
        {
            IList<RegularItem> actual = GetUpdatedItems<AgedBrie>(sellInActual, qualityActual, "Aged Brie");

            Assert.Equal(sellInExpected, actual[0].SellIn);
        }

        [Theory]
        [InlineData(1, 10, 0)]
        [InlineData(0, 10, -1)]
        [InlineData(-1, 0, -2)]
        public void UpdateQuality_BackstagePassesSellInIsCorrect(int sellInActual, int qualityActual, int sellInExpected)
        {
            IList<RegularItem> actual = GetUpdatedItems<BackstagePass>(sellInActual, qualityActual, "Backstage passes to a TAFKAL80ETC concert");

            Assert.Equal(sellInExpected, actual[0].SellIn);
        }

        [Theory]
        [InlineData(1, 10, 0)]
        [InlineData(0, 10, -1)]
        [InlineData(-1, 0, -2)]
        public void UpdateQuality_RegularItemSellInIsCorrect(int sellInActual, int qualityActual, int sellInExpected)
        {
            IList<RegularItem> actual = GetUpdatedItems<RegularItem>(sellInActual, qualityActual, "Elixir of the Mongoose");

            Assert.Equal(sellInExpected, actual[0].SellIn);
        }

        [Theory]
        [InlineData(1, 10, 0)]
        [InlineData(0, 10, -1)]
        [InlineData(-1, 0, -2)]
        public void UpdateQuality_ConjuredSellInIsCorrect(int sellInActual, int qualityActual, int sellInExpected)
        {
            IList<RegularItem> actual = GetUpdatedItems<Conjured>(sellInActual, qualityActual, "Conjured Mana Cake");

            Assert.Equal(sellInExpected, actual[0].SellIn);
        }
        #endregion

        private static IList<RegularItem> GetUpdatedItems<T>(int sellInActual, int qualityActual, string itemName) where T : RegularItem, new()
        {
            Program.Items = new List<RegularItem>
            {
                new T {Name = itemName , SellIn = sellInActual, Quality = qualityActual}
            };

            Program.Items[0].UpdateQuality();

            return Program.Items;
        }

    }
}