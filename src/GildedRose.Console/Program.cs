using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        private const string AgedBrie = "Aged Brie";
        private const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        private const int MaxQuality = 50;
        IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
            {
                Items = new List<Item>
                                          {
                                              new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                              new Item {Name = AgedBrie, SellIn = 2, Quality = 0},
                                              new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                              new Item {Name = Sulfuras, SellIn = 0, Quality = 80},
                                              new Item
                                                  {
                                                      Name = BackstagePasses,
                                                      SellIn = 15,
                                                      Quality = 20
                                                  },
                                              new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                                          }

            };

            app.UpdateQuality(app.Items);

            System.Console.ReadKey();

        }

        public void UpdateQuality(IList<Item> Items)
        {
            for (var i = 0; i < Items.Count; i++)
            {
                var item = Items[i];

                if (!IsAgingItem(item) && !IsScalpingItem(item))
                {
                    ReduceQuality(item);

                    UpdateSellIn(item);

                    if (PastSellIn(item))
                    {
                        ReduceQuality(item);
                    }
                }

                if (IsAgingItem(item))
                {
                    IncreaseQuality(item);

                    UpdateSellIn(item);

                    if (PastSellIn(item))
                    {
                        IncreaseQuality(item);
                    }
                }

                if (IsScalpingItem(item))
                {
                    IncreaseQuality(item);

                    if (item.SellIn < 11)
                    {
                        IncreaseQuality(item);
                    }

                    if (item.SellIn < 6)
                    {
                        IncreaseQuality(item);
                    }

                    UpdateSellIn(item);

                    if (PastSellIn(item))
                    {
                        item.Quality = 0;
                    }

                }
            }
        }

        private static bool PastSellIn(Item item)
        {
            return item.SellIn < 0;
        }

        private static void ReduceQuality(Item item)
        {
            if (item.Quality > 0)
            {
                if (!IsPristineItem(item))
                {
                    item.Quality = item.Quality - 1;
                }
            }
        }

        private static void IncreaseQuality(Item item)
        {
            if (item.Quality < MaxQuality)
            {
                item.Quality = item.Quality + 1;
            }
        }

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

        private static void UpdateSellIn(Item item)
        {
            if (item.Name != Sulfuras)
            {
                item.SellIn = item.SellIn - 1;
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}
