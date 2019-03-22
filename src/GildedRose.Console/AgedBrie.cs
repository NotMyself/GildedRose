using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    class AgedBrie : RegularItem
    {
        public override void UpdateQuality()
        {
            if (Quality < 50)
            {
                Quality = Quality + 1;
            }
            SellIn = SellIn - 1;
            if (SellIn < 0)
            {
                if (Quality < 50)
                {
                    Quality = Quality + 1;
                }
            }
        }
    }
}
