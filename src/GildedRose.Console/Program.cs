using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public IList<Item> Items;

        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
                          {
                              Items = new List<Item>
                                          {
                                              new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                              new AgedBrieItem(sellIn: 2, quality: 0),
                                              new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                              new SulfurasItem(sellIn: 0, quality: 80),
                                              new BackstageItem(sellIn: 15, quality: 20),
                                              new ConjuredItem(sellIn: 3, quality: 6)
                                          }

                          };

            app.UpdateQuality();

            System.Console.ReadKey();

        }

        public void UpdateQuality()
        {
            new Inn(this.Items).UpdateItem();
        }

    }
}
