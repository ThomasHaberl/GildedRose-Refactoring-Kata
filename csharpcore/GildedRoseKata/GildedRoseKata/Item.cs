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
    }


    /*
    public interface IItem
    {
        void UpdateQuality();
    }


    public class RegularItem
        : Item, IItem
    {
        public void UpdateQuality()
        {
            throw new System.NotImplementedException();
        }
    }

    public class AgedBrieItem
        : Item, IItem
    {
        public void UpdateQuality()
        {
            throw new System.NotImplementedException();
        }
    }

    public class LegendaryItem
        : Item, IItem
    {
        public void UpdateQuality()
        {
            throw new System.NotImplementedException();
        }
    }

    public class ConjuredItem
        : Item, IItem
    {
        public void UpdateQuality()
        {
            throw new System.NotImplementedException();
        }
    }

    public class BackstagePassItem
        : Item, IItem
    {
        public void UpdateQuality()
        {
            throw new System.NotImplementedException();
        }
    }
    */
}
