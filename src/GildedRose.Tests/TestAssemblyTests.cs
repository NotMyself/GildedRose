using Xunit;
using GildedRose.Console;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        [Fact]
        public void TestObjectName()
        {
            Item item = new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 };
            Assert.Equal(item.Name, "+5 Dexterity Vest");
        }
        [Fact]
        public void Item_WithinSellinTimePeriod_QualityDegradesByOnePointPerDay()
        {

        }
        [Fact]
        public void Item_PastSellinTimePeriod_QualityDegradesByTwoPoints()
        {

        }
        [Fact]
        public void Item_PastQualityDegradationMax_QualityIsNeverNegative()
        {

        }
        [Fact]
        public void Item_NamedBrie_QualityIncreasesWithAge()
        {

        }
        [Fact]
        public void Item_NamedSulfuras_NeverHasToBeSoldOrDecreasesValue()
        {

        }
        [Fact]
        public void Item_NamedSulfuras_HasValueOf80()
        {

        }
        [Fact]
        public void Item_QualityIncreases_QualityNeverExceedsMaxValue()
        {

        }
        [Fact]
        public void Item_BackStagePass_IncreaseInValueTowardsSellin()
        {

        }
    }

}