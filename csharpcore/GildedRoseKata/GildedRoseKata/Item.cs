using System;

namespace GildedRoseKata
{
    /// <summary>
    /// An item in the Gilded Rose inventory.
    /// 
    /// --- NOT TO BE MODIFIED ---
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("Name = \"{Name}\", SellIn = {SellIn}, Quality = {Quality}")]
    public class Item
    {
        /// <summary>
        /// The maximum possible quality value for items in the inventory.
        /// </summary>
        private const int MaximumQuality = 50;



        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///  Gets or sets the number of days left until the item should be sold.
        /// </summary>
        public int SellIn { get; set; }
        /// <summary>
        /// Gets or sets the quality of the item. This value will never be negative or higher than 50.
        /// </summary>
        public int Quality { get; set; }



        /// <summary>
        /// Updates the quality of the item under the assumption that one day has passed.
        /// </summary>
        public void UpdateQuality()
        {
            switch (Name)
            {
                case "Aged Brie":
                    if (SellIn > 0)
                    {
                        Quality = Math.Min(Quality + 1, MaximumQuality);
                    }
                    else
                    {
                        Quality = Math.Min(Quality + 2, MaximumQuality);
                    }

                    SellIn--;

                    break;

                case "Backstage passes to a TAFKAL80ETC concert":
                    if (SellIn > 10)
                    {
                        Quality = Math.Min(Quality + 1, MaximumQuality);
                    }
                    else if (SellIn > 5)
                    {
                        Quality = Math.Min(Quality + 2, MaximumQuality);
                    }
                    else if (SellIn > 0)
                    {
                        Quality = Math.Min(Quality + 3, MaximumQuality);
                    }
                    else
                    {
                        Quality = 0;
                    }

                    SellIn--;

                    break;

                case "Sulfuras, Hand of Ragnaros":
                    // No change
                    break;

                default:
                    if (SellIn > 0)
                    {
                        Quality = Math.Max(Quality - 1, 0);
                    }
                    else
                    {
                        Quality = Math.Max(Quality - 2, 0);
                    }

                    SellIn--;

                    break;
            }
        }
    }
}
