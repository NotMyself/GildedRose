using GildedRose.Console;
using System.Collections.Generic;
using System.Linq;
using Xunit;

public class BackstagePassTests {
	private const string Name = "Backstage passes to a TAFKAL80ETC concert";

	public static IEnumerable<object[]> TestData {
		get {
			return new[] {
				new TestDatum {
					SellIn = 11,
					InitialQuality = 10,
					ExpectedQuality = 11,
				},
				new TestDatum {
					SellIn = 10,
					InitialQuality = 10,
					ExpectedQuality = 12,
				},
				new TestDatum {
					SellIn = 9,
					InitialQuality = 10,
					ExpectedQuality = 12,
				},
				new TestDatum {
					SellIn = 6,
					InitialQuality = 10,
					ExpectedQuality = 12,
				},
				new TestDatum {
					SellIn = 5,
					InitialQuality = 10,
					ExpectedQuality = 13,
				},
				new TestDatum {
					SellIn = 4,
					InitialQuality = 10,
					ExpectedQuality = 13,
				},
				new TestDatum {
					SellIn = 1,
					InitialQuality = 10,
					ExpectedQuality = 13,
				},
				new TestDatum {
					SellIn = 0,
					InitialQuality = 10,
					ExpectedQuality = 0,
				},
				new TestDatum {
					SellIn = -1,
					InitialQuality = 10,
					ExpectedQuality = 0,
				},
				new TestDatum {
					SellIn = 11,
					InitialQuality = 50,
					ExpectedQuality = 50,
				},
				new TestDatum {
					SellIn = 4,
					InitialQuality = 50,
					ExpectedQuality = 50,
				},
				new TestDatum {
					SellIn = 4,
					InitialQuality = 49,
					ExpectedQuality = 50,
				},
				new TestDatum {
					SellIn = 1,
					InitialQuality = 50,
					ExpectedQuality = 50,
				},
				new TestDatum {
					SellIn = 1,
					InitialQuality = 49,
					ExpectedQuality = 50,
				},
				new TestDatum {
					SellIn = 1,
					InitialQuality = 48,
					ExpectedQuality = 50,
				},
			}
			.Select(i => new object[] { i });
		}
	}

	[Theory]
	[MemberData(nameof(TestData))]
	public void BackstagePassRulesFollowed(TestDatum datum) {
		var item = new Item { Name = Name, Quality = datum.InitialQuality, SellIn = datum.SellIn };

		var sut = new Program { Items = new[] { item } };
		sut.UpdateQuality();

		Assert.Equal(datum.ExpectedQuality, item.Quality);
	}
}

public struct TestDatum {
	public int SellIn;
	public int InitialQuality;
	public int ExpectedQuality;

	public override string ToString() {
		return $"SI {SellIn}; IQ {InitialQuality}; EQ {ExpectedQuality}";
	}
}