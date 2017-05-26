namespace GildedRose.Console
{
    public class DexterityVestItem : Item
    {
        public override void UpdateQuality()
        {
            SellIn--;

            Quality--;
        }
    }
}