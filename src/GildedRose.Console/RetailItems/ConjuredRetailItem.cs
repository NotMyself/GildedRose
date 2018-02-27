namespace GildedRose.Console.RetailItems
{
    public class ConjuredRetailItem : StandardRetailItem
    {
        public ConjuredRetailItem(Item item): base(item) { }

        public override void UpdateQuality()
        {
            base.UpdateQuality();

            ReduceQuality();

            if (PastSellIn())
            {
                ReduceQuality();
            }
        }
    }
}
