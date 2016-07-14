using GildedRose.Inventory.Domain;
using GildedRose.Inventory.Domain.Entities;
using GildedRose.Inventory.Domain.Logic;
using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        private static IList<Item> Items;

        static void Main(string[] args)
        {
            System.Console.WriteLine("Gilded Rose - Inventory Processing Utility");

            Items = LoadInventoryItems();
            PrintItems("Inventory items before processing:", Items);
            UpdateQuality();
            PrintItems("Inventory items after processing:", Items);

            System.Console.WriteLine("\nPress any key to quit.");
            System.Console.ReadKey();
        }

        private static void UpdateQuality()
        {
            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(Items);
        }

        private static void PrintItems(string message, IList<Item> items)
        {
            System.Console.WriteLine();
            System.Console.WriteLine(message);
            foreach (var item in items)
                System.Console.WriteLine(item.ToString());
        }

        private static List<Item> LoadInventoryItems()
        {
            InventoryLoader inventoryLoader = new InventoryLoader();
            List<Item> inventoryItems = inventoryLoader.LoadInventoryItems();

            return inventoryItems;
        }
    }
}
