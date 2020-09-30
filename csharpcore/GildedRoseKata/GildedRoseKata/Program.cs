using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class Program
    {
        public static void Main()
        {
            // Initialize the list of inventory items
            IList<Item> items = new List<Item>{
                Item.CreateItem("+5 Dexterity Vest", 10, 20),
                Item.CreateItem("Aged Brie", 2, 0),
                Item.CreateItem("Elixir of the Mongoose", 5, 7),
                Item.CreateItem("Sulfuras, Hand of Ragnaros", 0, 80),
                Item.CreateItem("Sulfuras, Hand of Ragnaros", -1, 80),
                Item.CreateItem("Backstage passes to a TAFKAL80ETC concert", 15, 20),
                Item.CreateItem("Backstage passes to a TAFKAL80ETC concert", 10, 49),
                Item.CreateItem("Backstage passes to a TAFKAL80ETC concert", 5, 49),
				// This conjured item does not work properly yet
                Item.CreateItem("Conjured Mana Cake", 3, 6),
            };

            var app = new GildedRose(items);

            // Simulate a month of quality updating
            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");

                foreach (var item in items)
                {
                    Console.WriteLine(item.Name + ", " + item.SellIn + ", " + item.Quality);
                }

                Console.WriteLine("");

                app.UpdateQuality();
            }
        }
    }
}
