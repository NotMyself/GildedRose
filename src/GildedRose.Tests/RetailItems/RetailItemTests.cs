using FakeItEasy;
using GildedRose.Console;
using GildedRose.Console.RetailItems;
using Xunit;

namespace GildedRose.Tests.RetailItems
{
    public class RetailItemTests
    {
        [Fact]
        public void PastSellIn_LessThanZero_ReturnsTrue()
        {
            var item = new Item { Name = "Aged Brie", SellIn = -1, Quality = 0 };
            var mockRetailItem = new MockRetailItem(item);

            Assert.True(mockRetailItem.PastSellIn());

        }

        [Fact]
        public void ReduceQuality_QualityZero_RemainsZero()
        {
            var item = new Item { Name = "Aged Brie", SellIn = 10, Quality = 0 };
            var mockRetailItem = new MockRetailItem(item);

            mockRetailItem.ReduceQuality();

            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void ReduceQuality_QualityAboveZero_ReducesQuality()
        {
            var item = new Item { Name = "Aged Brie", SellIn = 10, Quality = 2 };
            var mockRetailItem = new MockRetailItem(item);

            mockRetailItem.ReduceQuality();

            Assert.Equal(1, item.Quality);
        }

        [Fact]
        public void IncreaseQuality_QualityFifty_RemainsFifty()
        {
            var item = new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 };
            var mockRetailItem = new MockRetailItem(item);

            mockRetailItem.IncreaseQuality();

            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void IncreaseQuality_QualityBelowFifty_IncreaseQuality()
        {
            var item = new Item { Name = "Aged Brie", SellIn = 10, Quality = 30 };
            var mockRetailItem = new MockRetailItem(item);

            mockRetailItem.IncreaseQuality();

            Assert.Equal(31, item.Quality);
        }

        [Fact]
        public void UpdateSellin_WhenCalled_ReducesSellin()
        {
            var item = new Item { Name = "Aged Brie", SellIn = 10, Quality = 30 };
            var mockRetailItem = new MockRetailItem(item);

            mockRetailItem.UpdateSellin();

            Assert.Equal(9, item.SellIn);
        }

        public class MockRetailItem : RetailItem
        {
            public MockRetailItem(Item item) : base(item) { }

            public override void UpdateQuality() => throw new System.NotImplementedException();

            public new bool PastSellIn() => base.PastSellIn();

            public new void ReduceQuality() => base.ReduceQuality();

            public new void IncreaseQuality() => base.IncreaseQuality();

            public new void UpdateSellin() => base.UpdateSellIn();

        }


    }

}
