namespace GildedRose.Console.RetailItems
{
    public class ScalpingRetailItem : RetailItem
    {
        public ScalpingRetailItem(Item item) : base(item) { }

        public override void UpdateQuality()
        {
            IncreaseQuality();

            if (Item.SellIn < 11)
            {
                IncreaseQuality();
            }

            if (Item.SellIn < 6)
            {
                IncreaseQuality();
            }

            UpdateSellIn();

            if (PastSellIn())
            {
                Item.Quality = 0;
            }
        }
    }

}
