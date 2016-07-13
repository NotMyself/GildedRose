using System;

namespace GildedRose.Inventory.Domain
{
    /// <summary>
    /// Represents an inventory item.
    /// </summary>
    /// <remarks>
    /// This class has been left as-is, as per the instructions. The class was relocated
    /// to a more appropriate assembly, but the class members were not modified.
    /// </remarks>
    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }
}
