using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    /// <summary>
    /// The Gilded Rose inventory of items for sale.
    /// </summary>
    public class GildedRose
    {
        /// <summary>
        /// The list of items in the inventory.
        /// 
        /// --- NOT TO BE MODIFIED ---
        /// </summary>
        private readonly IList<Item> Items;

        /// <summary>
        /// The maximum possible quality value for items in the inventory.
        /// </summary>
        private const int MaximumQuality = 50;



        /// <summary>
        /// Initializes a new instance with the provided list of items.
        /// </summary>
        /// <param name="items">The list of items in the inventory.</param>
        public GildedRose(IList<Item> items)
        {
            this.Items = items;
        }



        /// <summary>
        /// Updates the quality value of the items in the inventory.
        /// </summary>
        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                switch (item.Name)
                {
                    case "Aged Brie":
                        if (item.SellIn > 0)
                        {
                            item.Quality = Math.Min(item.Quality + 1, MaximumQuality);
                        }
                        else
                        {
                            item.Quality = Math.Min(item.Quality + 2, MaximumQuality);
                        }

                        item.SellIn--;

                        break;

                    case "Backstage passes to a TAFKAL80ETC concert":
                        if (item.SellIn > 10)
                        {
                            item.Quality = Math.Min(item.Quality + 1, MaximumQuality);
                        }
                        else if (item.SellIn > 5)
                        {
                            item.Quality = Math.Min(item.Quality + 2, MaximumQuality);
                        }
                        else if (item.SellIn > 0)
                        {
                            item.Quality = Math.Min(item.Quality + 3, MaximumQuality);
                        }
                        else
                        {
                            item.Quality = 0;
                        }

                        item.SellIn--;

                        break;

                    case "Sulfuras, Hand of Ragnaros":
                        // No change
                        break;

                    default:
                        if (item.SellIn > 0)
                        {
                            item.Quality = Math.Max(item.Quality - 1, 0);
                        }
                        else
                        {
                            item.Quality = Math.Max(item.Quality - 2, 0);
                        }

                        item.SellIn--;

                        break;
                }
            }
        }
    }
}
