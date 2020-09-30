﻿using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class Program
    {
        public static void Main()
        {
            // Initialize the list of inventory items
            IList<Item> items = new List<Item>{
                ItemFactory.CreateItem("+5 Dexterity Vest", 10, 20),
                ItemFactory.CreateItem("Aged Brie", 2, 0),
                ItemFactory.CreateItem("Elixir of the Mongoose", 5, 7),
                ItemFactory.CreateItem("Sulfuras, Hand of Ragnaros", 0, 80),
                ItemFactory.CreateItem("Sulfuras, Hand of Ragnaros", -1, 80),
                ItemFactory.CreateItem("Backstage passes to a TAFKAL80ETC concert", 15, 20),
                ItemFactory.CreateItem("Backstage passes to a TAFKAL80ETC concert", 10, 49),
                ItemFactory.CreateItem("Backstage passes to a TAFKAL80ETC concert", 5, 49),
                ItemFactory.CreateItem("Conjured Mana Cake", 3, 6),
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
