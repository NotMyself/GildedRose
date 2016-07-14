using GildedRose.Inventory.Domain;
using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public static IList<Item> Items;

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

        public static void UpdateQuality()
        {
            InventoryProcessor inventoryProcessor = new InventoryProcessor();
            inventoryProcessor.UpdateQuality(Items);
        }

        public static void PrintItems(string message, IList<Item> items)
        {
            System.Console.WriteLine();
            System.Console.WriteLine(message);
            foreach (var item in items)
                System.Console.WriteLine(item.ToString());
        }

        public static List<Item> LoadInventoryItems()
        {
            List<Item> inventoryItems = new List<Item>()
            {
                new InventoryItem {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20, Type = ItemType.Deprecating, QualityRules =
                {
                    new QualityRule() { MinSellIn = null, MaxSellIn = -1, Adjustment = QualityAdjustment.Decrease, Rate = 2 },
                    new QualityRule() { MinSellIn = 0, MaxSellIn = null, Adjustment = QualityAdjustment.Decrease, Rate = 1 }
                } },
                new InventoryItem {Name = "Aged Brie", SellIn = 2, Quality = 0, Type = ItemType.Appreciating, QualityRules =
                {
                    new QualityRule() { MinSellIn = null, MaxSellIn = -1, Adjustment = QualityAdjustment.Increase, Rate = 2 },
                    new QualityRule() { MinSellIn = 0, MaxSellIn = null, Adjustment = QualityAdjustment.Increase, Rate = 1 }
                } },
                new InventoryItem {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7, Type = ItemType.Deprecating, QualityRules =
                {
                    new QualityRule() { MinSellIn = null, MaxSellIn = -1, Adjustment = QualityAdjustment.Decrease, Rate = 2 },
                    new QualityRule() { MinSellIn = 0, MaxSellIn = null, Adjustment = QualityAdjustment.Decrease, Rate = 1 }
                } },
                new InventoryItem {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80, Type = ItemType.Fixed, QualityRules =
                {
                    new QualityRule() { MinSellIn = null, MaxSellIn = null, Adjustment = QualityAdjustment.None, Rate = null }
                } },
                new InventoryItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20, Type = ItemType.AppreciatingTiered, QualityRules =
                {
                    new QualityRule() { MinSellIn = null, MaxSellIn = -1, Adjustment = QualityAdjustment.SetToMin, Rate = null },
                    new QualityRule() { MinSellIn = 0, MaxSellIn = 5, Adjustment = QualityAdjustment.Increase, Rate = 3 },
                    new QualityRule() { MinSellIn = 6, MaxSellIn = 10, Adjustment = QualityAdjustment.Increase, Rate = 2 },
                    new QualityRule() { MinSellIn = 11, MaxSellIn = null, Adjustment = QualityAdjustment.Increase, Rate = 1 }
                }},
                new InventoryItem {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6, Type = ItemType.Deprecating, QualityRules =
                {
                    new QualityRule() { MinSellIn = null, MaxSellIn = -1, Adjustment = QualityAdjustment.Decrease, Rate = 4 },
                    new QualityRule() { MinSellIn = 0, MaxSellIn = null, Adjustment = QualityAdjustment.Decrease, Rate = 2 }
                }}
            };

            return inventoryItems;
        }
    }
}
