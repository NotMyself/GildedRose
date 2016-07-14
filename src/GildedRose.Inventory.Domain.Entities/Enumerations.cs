using System;

namespace GildedRose.Inventory.Domain.Entities
{
    public enum ItemType
    {
        Deprecating = 0,
        Appreciating = 1,
        Fixed = 2,
        DeprecatingTiered = 3,
        AppreciatingTiered = 4
    }

    public enum QualityAdjustment
    {
        None = 0,
        Decrease = 1,
        Increase = 2,
        SetToMin = 3
    }
}
