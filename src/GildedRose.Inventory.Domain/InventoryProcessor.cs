using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Inventory.Domain
{
    public class InventoryProcessor
    {
        public void UpdateQuality(IList<Item> items)
        {
            for (var i = 0; i < items.Count; i++)
            {
                UpdateQuality(items[i] as InventoryItem);
            }
        }

        public void UpdateQuality(InventoryItem item)
        {
            if (item.Type == ItemType.Deprecating)
                UpdateDepreciatingItemQuality(item);
            else if (item.Type == ItemType.Appreciating)
                UpdateAppreciatingItemQuality(item);
            else if (item.Type == ItemType.Fixed)
                UpdateFixedItemQuality(item);
            else if (item.Type == ItemType.AppreciatingTiered)
                UpdateAppreciatingTieredItemQuality(item);
        }

        public void UpdateDepreciatingItemQuality(InventoryItem item)
        {
            item.SellIn--;
            if (item.Quality > 0)
                item.Quality -= item.SellIn > 0 ? 1 : 2;
        }

        public void UpdateAppreciatingItemQuality(InventoryItem item)
        {
            item.SellIn--;
            if (item.Quality < 50)
                item.Quality += item.SellIn > 0 ? 1 : 2;
        }

        public void UpdateFixedItemQuality(InventoryItem item)
        {
            //For now we do nothing for fixed items.
        }

        public void UpdateAppreciatingTieredItemQuality(InventoryItem item)
        {
            item.SellIn--;

            if (item.SellIn < 0)
                item.Quality = 0;
            else if (item.Quality < 50)
            {
                if (item.SellIn <= 5)
                    item.Quality += 3;
                else if (item.SellIn <= 10)
                    item.Quality += 2;
                else
                    item.Quality += 1;
            }
        }
    }
}
