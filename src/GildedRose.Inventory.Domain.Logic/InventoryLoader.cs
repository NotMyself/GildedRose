using GildedRose.Inventory.Data;
using GildedRose.Inventory.Domain.Entities;
using GildedRose.Inventory.Domain.Entities.Validation;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Inventory.Domain.Logic
{
    /// <summary>
    /// Responsible for loading inventory items from an external source.
    /// </summary>
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

            //Note - we are just simulating an example scenario where we need to validate
            //the entities we load, and would consider invalid entities exceptional.
            //There are additional cases (like non-exceptional UI validation) not covered here.
            InventoryItemValidator validator = new InventoryItemValidator();
            foreach(var inventoryItem in inventoryItems.Cast<InventoryItem>())
            {
                validator.Validate(inventoryItem);
            }

            return inventoryItems;
        }
    }
}
