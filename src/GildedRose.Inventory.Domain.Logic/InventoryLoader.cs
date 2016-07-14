using GildedRose.Inventory.Data;
using GildedRose.Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Inventory.Domain.Logic
{
    public class InventoryLoader
    {
        public List<Item> LoadInventoryItems()
        {
            InventoryItemRepository inventoryItemRepo = new InventoryItemRepository();
            List<Item> inventoryItems = inventoryItemRepo.LoadInventoryItems();

            return inventoryItems;
        }
    }
}
