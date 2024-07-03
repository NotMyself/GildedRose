namespace GildedRose.Console
{
    public class ConjuredItem : Item
    {
        public ConjuredItem(int sellIn, int quality) : base()
        {
            this.Name = "Conjured Mana Cake";
            this.SellIn = sellIn;
            this.Quality = quality;
        }

        public override void Update()
        {
            this.UpdateQuality();
            this.UpdateQuality();
            this.DecreaseSellIn();
        }
    }
}
