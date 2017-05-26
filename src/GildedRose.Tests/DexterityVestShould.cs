using Xunit;

namespace GildedRose.Tests
{
    public class DexterityVestShould
    {
        [Fact]
        public void Reduce_The_Sell_In_When_Updating_Quality()
        {
            // Arrange
            var dexterityVest = new DexterityVest()
            {
                SellIn = 10,
                Quality = 4
            };

            // Act
            dexterityVest.UpdateQuality();

            //  Assert
            Assert.Equal(dexterityVest.SellIn,9);
        }

        [Fact]
        public void Reduce_The_Update_In_When_Updating_Quality()
        {
            // Arrange
            var dexterityVest = new DexterityVest()
            {
                SellIn = 10,
                Quality = 4
            };

            // Act
            dexterityVest.UpdateQuality();

            //  Assert
            Assert.Equal(dexterityVest.Quality, 3);
        }
    }
}