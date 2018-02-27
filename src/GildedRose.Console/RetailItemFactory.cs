namespace GildedRose.Console
{
    public static class RetailItemFactory
    {
        private const string AgedBrie = "Aged Brie";
        private const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";

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

            return new StandardRetailItem(item);
        }
    }
}
