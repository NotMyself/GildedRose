using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class Adapter
    {

        protected Item _item;

        public string Name => _item.Name;
        public int SellIn => _item.SellIn;
        public int Quality => _item.Quality;

        public Adapter(Item item)
        {
            _item = item;
        }

        public virtual void DailyChange()
        {
            _item.SellIn--;
            
            if(SellIn<0)
            {
                _item.Quality --;
            }
            _item.Quality--;
            RangeOfQuality();

        }
        public virtual void RangeOfQuality()
        {
            _item.Quality = Math.Max(0, Math.Min(50, _item.Quality));
        }

    }
}
