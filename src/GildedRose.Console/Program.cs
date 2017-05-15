using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
                          {
                              Items = new List<Item>
                                          {
                                              new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                              new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                              new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                              new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                              new Item
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 15,
                                                      Quality = 20
                                                  },
                                              new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                                          }

                          };

            app.Items = UpdateQuality(app.Items);

            System.Console.ReadKey();

        }

        public static IList<Item> UpdateQuality(IList<Item> items)
        {
            foreach (Item currentItem in items)
            {
                if (currentItem.Name.ToLower().Contains("aged brie"))
                {
                    // Increase quality by 1 if before sell by
                    if (currentItem.SellIn > 0)
                    {
                        currentItem.Quality = UpdateQualityBy(1, currentItem.Quality);
                    }
                    // Increase quality by 2 if after sell by
                    else
                    {
                        currentItem.Quality = UpdateQualityBy(2, currentItem.Quality);
                    }

                    currentItem.SellIn--;
                }
                else if (currentItem.Name.ToLower().Contains("sulfuras"))
                {
                    // Don't need to do anything - sell in will always be 0, quality will always be 80
                    continue;
                }
                else if (currentItem.Name.ToLower().Contains("backstage pass"))
                {
                    // Increase quality by 1 if over 10 days from sell by
                    if (currentItem.SellIn > 10)
                    {
                        currentItem.Quality = UpdateQualityBy(1, currentItem.Quality);
                    }
                    // Increase quality by 2 if between 5 and 10 days from sell by
                    else if (currentItem.SellIn <= 10 && currentItem.SellIn > 5)
                    {
                        currentItem.Quality = UpdateQualityBy(2, currentItem.Quality);
                    }
                    // Increase quality by 3 if between 0 and 5 days form sell by
                    else if (currentItem.SellIn <= 5 && currentItem.SellIn > 0)
                    {
                        currentItem.Quality = UpdateQualityBy(3, currentItem.Quality);
                    }
                    // Quality is always 0 after sell by
                    else
                    {
                        currentItem.Quality = 0;
                    }

                    currentItem.SellIn--;
                }
                else if (currentItem.Name.ToLower().Contains("conjured"))
                {
                    // Decrease quality by 2 before sell by
                    if (currentItem.SellIn > 0)
                    {
                        currentItem.Quality = UpdateQualityBy(-2, currentItem.Quality);
                    }
                    // Decrease quality by 4 after sell by
                    else
                    {
                        currentItem.Quality = UpdateQualityBy(-4, currentItem.Quality);
                    }

                    currentItem.SellIn--;
                }
                else
                {
                    // Decrease quality by 1 before sell by
                    if (currentItem.SellIn > 0)
                    {
                        currentItem.Quality = UpdateQualityBy(-1, currentItem.Quality);
                    }
                    // Decrease quality by 2 before sell by
                    else
                    {
                        currentItem.Quality = UpdateQualityBy(-2, currentItem.Quality);
                    }

                    currentItem.SellIn--;
                }
            }

            return items;
        }

        /// <summary>
        /// Method to update quality whilst also handling quality range
        /// </summary>
        /// <param name="amount">The amount to increase the quality by</param>
        /// <param name="currentQuality">The current quality value</param>
        /// <returns>The new quality between 0 and 50</returns>
        private static int UpdateQualityBy(int amount, int currentQuality)
        {
            currentQuality = currentQuality + amount;

            if (currentQuality > 50)
                return 50;

            if (currentQuality < 0)
                return 0;

            return currentQuality;
        }

    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}
