using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
     public class LegendaryItem:Adapter
    {
        public LegendaryItem(Item item) : base(item)
        {

        }

        public override void DailyChange()
        {

            RangeOfQuality();
        }

        public override void RangeOfQuality()
        {
            _item.Quality = 80;
        }


    }
}
