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
        public void ReduceQuality_ReduceBelowZero_RemainsZero()
        {
            var item = new Item { Name = "Aged Brie", SellIn = 10, Quality = 1 };
            var mockRetailItem = new MockRetailItem(item);

            mockRetailItem.ReduceQuality(3);

            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void ReduceQuality_QualityAboveZero_ReducesQuality()
        {
            var item = new Item { Name = "Aged Brie", SellIn = 10, Quality = 3 };
            var mockRetailItem = new MockRetailItem(item);

            mockRetailItem.ReduceQuality(2);

            Assert.Equal(1, item.Quality);
        }

        [Fact]
        public void IncreaseQuality_IncreaseQualityAboveFifty_RemainsFifty()
        {
            var item = new Item { Name = "Aged Brie", SellIn = 10, Quality = 49 };
            var mockRetailItem = new MockRetailItem(item);

            mockRetailItem.IncreaseQuality(2);

            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void IncreaseQuality_QualityBelowFifty_IncreaseQuality()
        {
            var item = new Item { Name = "Aged Brie", SellIn = 10, Quality = 30 };
            var mockRetailItem = new MockRetailItem(item);

            mockRetailItem.IncreaseQuality(3);

            Assert.Equal(33, item.Quality);
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

            public new void ReduceQuality(int amount) => base.ReduceQuality(amount);

            public new void IncreaseQuality(int amount) => base.IncreaseQuality(amount);

            public new void UpdateSellin() => base.UpdateSellIn();

        }


    }

}
