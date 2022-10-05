using GildedRose.Console;
using System.Linq;
using Xunit;

namespace GildedRose.Tests {
	public class ProgramTests {
		[Fact]
		public void UpdateQuality_UpdatesAllItems() {
			const int initialQuality = 10;
			const int expectedQuality = 9;
			var items = Enumerable
				.Range(1, 10)
				.Select(i => new Item { Name = i.ToString(), Quality = initialQuality, SellIn = 10 })
				.ToList();

			var sut = new Program { Items = items };
			sut.UpdateQuality();

			Assert.All(items, i => Assert.Equal(i.Quality, expectedQuality));
		}
	}
}
