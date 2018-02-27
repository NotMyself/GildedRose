namespace GildedRose.Console.RetailItems
{
    public class StandardRetailItem : RetailItem
    {
        public StandardRetailItem(Item item) : base(item) { }

        public override void UpdateQuality()
        {
            ReduceQuality();

            UpdateSellIn();

            if (PastSellIn())
            {
                ReduceQuality();
            }
        }
    }

}
