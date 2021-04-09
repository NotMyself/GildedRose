using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class ConjuredItem:Adapter
    {
        public ConjuredItem(Item item) : base(item)
        {

        }
        public override void DailyChange()
        {
            _item.SellIn--;

            if (SellIn < 0)
            {
                _item.Quality-=2;
            }
            _item.Quality-=2;
            RangeOfQuality();

        }
    }
}
