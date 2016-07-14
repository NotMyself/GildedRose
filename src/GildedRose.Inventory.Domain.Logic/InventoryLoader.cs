﻿using GildedRose.Inventory.Data;
using GildedRose.Inventory.Domain.Entities;
using System.Collections.Generic;

namespace GildedRose.Inventory.Domain.Logic
{
    public class InventoryLoader
    {
        public InventoryLoader()
            : base()
        {
        }

        public List<Item> LoadInventoryItems()
        {
            InventoryItemRepository inventoryItemRepo = new InventoryItemRepository();
            List<Item> inventoryItems = inventoryItemRepo.LoadInventoryItems();

            return inventoryItems;
        }
    }
}
