namespace GildedRose.Console
{
    public class AgedRetailItem : RetailItem
    {
        public AgedRetailItem(Item item) : base(item) { }

        public override void UpdateQuality()
        {
            IncreaseQuality();

            UpdateSellIn();

            if (PastSellIn())
            {
                IncreaseQuality();
            }
        }
    }

}
