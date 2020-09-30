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
                item.UpdateQuality();
            }
        }
    }
}
