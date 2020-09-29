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
                if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.Quality > 0)
                    {
                        if (item.Name != "Sulfuras, Hand of Ragnaros")
                        {
                            item.Quality--;
                        }
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality++;

                        if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (item.SellIn < 11)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality++;
                                }
                            }

                            if (item.SellIn < 6)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality++;
                                }
                            }
                        }
                    }
                }

                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.SellIn--;
                }

                if (item.SellIn < 0)
                {
                    if (item.Name != "Aged Brie")
                    {
                        if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (item.Quality > 0)
                            {
                                if (item.Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    item.Quality--;
                                }
                            }
                        }
                        else
                        {
                            item.Quality = 0;
                        }
                    }
                    else
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality++;
                        }
                    }
                }
            }
        }
    }
}
