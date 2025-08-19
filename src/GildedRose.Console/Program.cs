using System;
using System.Collections.Generic;

namespace GildedRose.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            IList<Item> items = new List<Item>
            {
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 },
                new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 },
            };

            var app = new GildedRose(items);

            // Print a clear table for several days.
            const int totalDays = 5;
            for (var day = 0; day < totalDays; day++)
            {
                System.Console.WriteLine("================= Day " + day + " =================");
                System.Console.WriteLine(string.Format("{0,-45} {1,7} {2,7}", "Name", "SellIn", "Quality"));
                System.Console.WriteLine(new string('-', 65));

                foreach (var it in items)
                {
                    System.Console.WriteLine(string.Format("{0,-45} {1,7} {2,7}", it.Name, it.SellIn, it.Quality));
                }

                System.Console.WriteLine();
                app.UpdateQuality();

                // Demo convenience: automatically remove inventory that’s past sell-in AND worthless.
                // Removes expired Backstage passes and junk that hit zero.
                var list = items as List<Item>;
                if (list != null)
                {
                    int removed = list.RemoveAll(i => i.SellIn < 0 && i.Quality == 0);
                    if (removed > 0)
                    {
                        System.Console.WriteLine("Removed " + removed + " expired/valueless item(s).");
                        System.Console.WriteLine();
                    }
                }
            }
        }
    }
}
