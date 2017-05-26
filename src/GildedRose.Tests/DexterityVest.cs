using GildedRose.Console;

namespace GildedRose.Tests
{
    public class DexterityVest : Item
    {
        public void UpdateQuality()
        {
            SellIn--;

            Quality--;
        }
    }
}