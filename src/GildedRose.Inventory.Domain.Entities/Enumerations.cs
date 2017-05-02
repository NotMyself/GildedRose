using System;

namespace GildedRose.Inventory.Domain.Entities
{
    /// <summary>
    /// The type of inventory item, with respect to its behavior over time.
    /// </summary>
    public enum ItemType
    {
        Deprecating = 0,
        Appreciating = 1,
        Fixed = 2,
        DeprecatingTiered = 3,
        AppreciatingTiered = 4
    }

    /// <summary>
    /// The adjustments that can be made to an inventory item's quality.
    /// </summary>
    public enum QualityAdjustment
    {
        None = 0,
        Decrease = 1,
        Increase = 2,
        SetToMin = 3
    }
}
