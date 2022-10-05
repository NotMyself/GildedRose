using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests {
	public class AgedBrieTests {
		private const string Name = "Aged Brie";

		[Fact]
		public void SellInRemainsPositive_QualityIncreasesByOne() {
			const int initialQuality = 10;
			int expectedQuality = initialQuality + 1;
			var item = new Item { Name = Name, Quality = initialQuality, SellIn = 10 };

			var sut = new Program { Items = new[] { item } };
			sut.UpdateQuality();

			Assert.Equal(expectedQuality, item.Quality);
		}

		[Fact]
		public void SellInGoesToZero_QualityIncreasesByOne() {
			const int initialQuality = 10;
			int expectedQuality = initialQuality + 1;
			var item = new Item { Name = Name, Quality = initialQuality, SellIn = 1 };

			var sut = new Program { Items = new[] { item } };
			sut.UpdateQuality();

			Assert.Equal(expectedQuality, item.Quality);
		}

		[Fact]
		public void SellInBecomesNegative_QualityIncreasesByTwo() {
			const int initialQuality = 10;
			int expectedQuality = initialQuality + 2;
			var item = new Item { Name = Name, Quality = initialQuality, SellIn = 0 };

			var sut = new Program { Items = new[] { item } };
			sut.UpdateQuality();

			Assert.Equal(expectedQuality, item.Quality);
		}

		[Fact]
		public void QualityAtFifty_DoesNotIncrease() {
			const int initialQuality = 50;
			int expectedQuality = initialQuality;
			var item = new Item { Name = Name, Quality = initialQuality, SellIn = 1 };

			var sut = new Program { Items = new[] { item } };
			sut.UpdateQuality();

			Assert.Equal(expectedQuality, item.Quality);
		}
	}
}
