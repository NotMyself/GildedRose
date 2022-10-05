using GildedRose.Console;
using System;
using Xunit;

namespace GildedRose.Tests {
	public class GenericItemTests {
		[Fact]
		public void SellInRemainsPositive_QualityDecreasesByOne() {
			const int initialQuality = 10;
			int expectedQuality = initialQuality - 1;
			var item = new Item { Name = Guid.NewGuid().ToString(), Quality = initialQuality, SellIn = 10 };

			var sut = new Program { Items = new[] { item } };
			sut.UpdateQuality();

			Assert.Equal(expectedQuality, item.Quality);
		}

		[Fact]
		public void SellInGoesToZero_QualityDecreasesByOne() {
			const int initialQuality = 10;
			int expectedQuality = initialQuality - 1;
			var item = new Item { Name = Guid.NewGuid().ToString(), Quality = initialQuality, SellIn = 1 };

			var sut = new Program { Items = new[] { item } };
			sut.UpdateQuality();

			Assert.Equal(expectedQuality, item.Quality);
		}

		[Fact]
		public void SellInBecomesNegative_QualityDecreasesByTwo() {
			const int initialQuality = 10;
			int expectedQuality = initialQuality - 2;
			var item = new Item { Name = Guid.NewGuid().ToString(), Quality = initialQuality, SellIn = 0 };

			var sut = new Program { Items = new[] { item } };
			sut.UpdateQuality();

			Assert.Equal(expectedQuality, item.Quality);
		}

		[Fact]
		public void QualityAtZero_DoesNotDecrease() {
			const int initialQuality = 0;
			int expectedQuality = initialQuality;
			var item = new Item { Name = Guid.NewGuid().ToString(), Quality = initialQuality, SellIn = 1 };

			var sut = new Program { Items = new[] { item } };
			sut.UpdateQuality();

			Assert.Equal(expectedQuality, item.Quality);
		}
	}
}
