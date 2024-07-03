namespace GildedRose.Console
{
    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }

        public virtual void Update()
        {
            this.UpdateQuality();

            this.DecreaseSellIn();

            if (this.SellIn < 0)
            {
                this.UpdateQuality();
            }
        }

        protected virtual void UpdateQuality()
        {
            if (this.Quality > 0)
            {
                this.Quality = this.Quality - 1;
            }
        }

        protected void DecreaseSellIn()
        {
            this.SellIn = this.SellIn - 1;
        }
    }
}
