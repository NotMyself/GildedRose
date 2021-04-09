using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class AgedBrieItem:Adapter
    {

        public AgedBrieItem(Item item) : base(item)
        {

        }

        public override void DailyChange()
        {
            _item.SellIn--;
            _item.Quality++;
            if (SellIn < 0)
            {
                _item.Quality++;
            }
            RangeOfQuality();
        }
    }
}
