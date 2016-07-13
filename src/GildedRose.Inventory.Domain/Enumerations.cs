using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Inventory.Domain
{
    public enum ItemType
    {
        Deprecating = 0,
        Appreciating = 1,
        Fixed = 2,
        DeprecatingTiered = 3,
        AppreciatingTiered = 4
    }
}
