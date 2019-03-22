using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    class RegularItem : Item
    {
        public virtual void UpdateQuality()
        {
            if (Quality > 0)
            {
                Quality = Quality - 1;
            }
            SellIn = SellIn - 1;
            if (SellIn < 0)
            {
                if (Quality > 0)
                {
                    Quality = Quality - 1;
                }
            }
        }
    }
}
