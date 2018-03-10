namespace GildedRose.Console.RetailItems
{
    public static class RetailItemFactory
    {
        private const string AgedBrie = "Aged Brie";
        private const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        private const string Conjured = "Conjured Mana Cake";

        private static bool IsScalpingItem(Item item)
        {
            return item.Name == BackstagePasses;
        }

        private static bool IsAgingItem(Item item)
        {
            return item.Name == AgedBrie;
        }

        private static bool IsPristineItem(Item item)
        {
            return item.Name == Sulfuras;
        }

        private static bool IsConjuredItem(Item item)
        {
            return item.Name == Conjured;
        }

        public static RetailItem CreateRetailItem(Item item)
        {
            if (IsScalpingItem(item))
            {
                return new ScalpingRetailItem(item);
            }

            if (IsPristineItem(item))
            {
                return new PristineRetailItem(item);
            }

            if (IsAgingItem(item))
            {
                return new AgedRetailItem(item);
            }

            if (IsConjuredItem(item))
            {
                return new ConjuredRetailItem(item);
            }
               
            return new StandardRetailItem(item);
        }
    }
}
