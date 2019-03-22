using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    class Conjured : RegularItem
    {
        public override void UpdateQuality()
        {
            if (Quality > 1)
            {
                Quality = Quality - 2;
            }
            else
            {
                Quality = 0;
            }
            SellIn = SellIn - 1;
            if (SellIn < 0)
            {
                if (Quality > 2)
                {
                    Quality = Quality - 2;
                }
                else
                {
                    Quality = 0;
                }
            }
        }
    }
}
