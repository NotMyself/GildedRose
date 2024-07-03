namespace GildedRose.Console
{
    public class BackstageItem : Item
    {
        public BackstageItem(int sellIn, int quality) : base()
        {
            this.Name = "Backstage passes to a TAFKAL80ETC concert";
            this.SellIn = sellIn;
            this.Quality = quality;
        }

        public override void Update()
        {
            this.UpdateQuality();

            if (this.SellIn < 11)
            {
                this.UpdateQuality();
            }

            if (this.SellIn < 6)
            {
                this.UpdateQuality();
            }

            this.DecreaseSellIn();

            if (this.SellIn < 0)
            {
                this.Quality = this.Quality - this.Quality;
            }
        }

        protected override void UpdateQuality()
        {
            if (this.Quality < 50)
            {
                this.Quality++;
            }
        }
    }
}
