using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    class Program
    {

        IList<Item> Items;

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                Console.WriteLine(item.Name + " " + item.Quality + " " + item.SellIn);
                var adapter = ItemFactory.Create(item);
                adapter.DailyChange();
                


            }
        }
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

            for(int i=0; i < 10; i++)
            {
                app.UpdateQuality();

            }

            System.Console.ReadKey();

        }



    }
}
