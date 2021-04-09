using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class BackstagePassItem:Adapter
    {

        public BackstagePassItem(Item item) : base(item)
        {

        }

        public override void DailyChange()
        {
            _item.Quality++;
            if (SellIn < 11)
            {
                _item.Quality++;
            }
            if(SellIn < 6)
            {
                _item.Quality++;
            }
            _item.SellIn--;
            if (_item.Quality < 0)
            {
                _item.Quality = 0;
            }
            RangeOfQuality();
        }


        //public void DailyChange()
        //{
        //    if (SellIn > 10)
        //    {
        //        Quality += 1;
        //    }
        //    else if (SellIn > 5)
        //    {
        //        Quality += 2;
        //    }
        //    else if (SellIn >= 0)
        //    {
        //        Quality += 3;
        //    }
        //    else
        //        Quality = 0;

        //    SellIn -= 1;
        //}
    }
}
