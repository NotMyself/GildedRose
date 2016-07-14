using GildedRose.Inventory.Domain.Entities;
using GildedRose.Inventory.Domain.Logic;
using System;
using System.Collections.Generic;

namespace GildedRose.Console
{
    /// <summary>
    /// Command line interface (CLI) for the Gilded Rose inventory processing utility.
    /// </summary>
    public class Program
    {
        private static IList<Item> Items;

        static void Main(string[] args)
        {
            System.Console.WriteLine("Gilded Rose - Inventory Processing Utility");

            try
            {
                Items = LoadInventoryItems();
                PrintItems("Inventory items before processing:", Items);
                UpdateQuality();
                PrintItems("Inventory items after processing:", Items);
            }
            catch (Exception ex)
            {
                //Simple error handling to display details to user.
                System.Console.WriteLine("\nAn error occurred while attempting to process inventory: {0}", ex.Message);
            }

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
