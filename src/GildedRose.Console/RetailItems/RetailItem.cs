namespace GildedRose.Console.RetailItems
{
    public abstract class RetailItem
    {
        private const int MaxQuality = 50;

        public Item Item { get; }

        public RetailItem(Item item)
        {
            Item = item;
        }

        protected bool PastSellIn()
        {
            return Item.SellIn < 0;
        }

        protected void ReduceQuality(int amount = 1)
        {
            Item.Quality = Item.Quality - amount;

            if (Item.Quality < 0)
            {
                Item.Quality = 0;
            }
        }

        protected void IncreaseQuality(int amount = 1)
        {
            Item.Quality = Item.Quality + amount;
            if (Item.Quality > MaxQuality)
            {
                Item.Quality = MaxQuality;
            }
        }

        protected void UpdateSellIn()
        {
            Item.SellIn = Item.SellIn - 1;
        }

        public abstract void UpdateQuality();

    }
}
