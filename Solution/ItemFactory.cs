using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public static class ItemFactory
    {
        public static Adapter Create(Item item)
        {
            if (item.Name.Contains("Sulfuras"))
                return new LegendaryItem(item);
            if (item.Name.Contains("Aged Brie"))
                return new AgedBrieItem(item);
            if (item.Name.Contains("Backstage passes"))
                return new BackstagePassItem(item);
            if (item.Name.Contains("Conjured"))
                return new ConjuredItem(item);

            return new Adapter(item);

        }

    }
}
