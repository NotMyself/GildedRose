using System.Collections.Generic;

namespace GildedRose.Console
{
    internal class Inn
    {
        public IReadOnlyList<Item> Items { get; }

        public Inn(IList<Item> items)
        {
            this.Items = ((List<Item>)items).AsReadOnly();
        }

        public void UpdateItem()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                Items[i].Update();
            }
        }
    }
}
