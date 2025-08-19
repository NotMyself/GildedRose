using System;
using System.Collections.Generic;

namespace GildedRose.Console
{
    public class GildedRose
    {
        private const int MaxQuality = 50;
        private const int MinQuality = 0;
        private const int SulfurasQuality = 80;

        public IList<Item> Items { get; private set; }

        public GildedRose(IList<Item> items)
        {
            if (items == null) throw new ArgumentNullException("items");
            Items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if (IsSulfuras(item))
                {
                    // Legendary: always 80 quality and never sold.
                    item.Quality = SulfurasQuality;
                    continue;
                }

                // 1) Apply per-day quality change based on current SellIn.
                if (IsAgedBrie(item))
                {
                    IncreaseQuality(item, 1);
                    if (item.SellIn <= 0) IncreaseQuality(item, 1); // faster after sell date
                }
                else if (IsBackstagePass(item))
                {
                    // Tiered increases as the concert approaches.
                    IncreaseQuality(item, 1);
                    if (item.SellIn <= 10) IncreaseQuality(item, 1);
                    if (item.SellIn <= 5) IncreaseQuality(item, 1);
                }
                else
                {
                    // Normal / Conjured degradation.
                    int loss = (item.SellIn <= 0) ? 2 : 1;
                    if (IsConjured(item)) loss *= 2;
                    DecreaseQuality(item, loss);
                }

                // 2) End-of-day: decrement SellIn.
                item.SellIn = item.SellIn - 1;

                // 3) Post-day special rule for Backstage: after the concert, quality is 0.
                if (IsBackstagePass(item) && item.SellIn < 0)
                {
                    item.Quality = 0;
                }

                // 4) Final clamp to enforce quality constraints globally (non-legendary).
                ClampQuality(item);
            }
        }

        // ---------- Helper predicates ----------
        private static bool IsSulfuras(Item i)
        {
            return i.Name == "Sulfuras, Hand of Ragnaros";
        }

        private static bool IsAgedBrie(Item i)
        {
            return i.Name == "Aged Brie";
        }

        private static bool IsBackstagePass(Item i)
        {
            return i.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        private static bool IsConjured(Item i)
        {
            return i.Name != null && i.Name.StartsWith("Conjured", StringComparison.OrdinalIgnoreCase);
        }

        // ---------- Quality utilities ----------
        private static void IncreaseQuality(Item i, int by)
        {
            if (by <= 0) return;
            i.Quality = Math.Min(MaxQuality, i.Quality + by);
        }

        private static void DecreaseQuality(Item i, int by)
        {
            if (by <= 0) return;
            i.Quality = Math.Max(MinQuality, i.Quality - by);
        }

        private static void ClampQuality(Item i)
        {
            if (IsSulfuras(i))
            {
                i.Quality = SulfurasQuality;
                return;
            }

            if (i.Quality < MinQuality) i.Quality = MinQuality;
            if (i.Quality > MaxQuality) i.Quality = MaxQuality;
        }
    }

    // DO NOT CHANGE
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
    }
}
