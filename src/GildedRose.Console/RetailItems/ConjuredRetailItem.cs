namespace GildedRose.Console.RetailItems
{
    public class ConjuredRetailItem : StandardRetailItem
    {
        public ConjuredRetailItem(Item item): base(item) { }

        protected override void ReduceQuality()
        {
            base.ReduceQuality();
            base.ReduceQuality();
        }

    }
}
