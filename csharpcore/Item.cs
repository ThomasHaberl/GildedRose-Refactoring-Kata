namespace csharpcore
{
    /// <summary>
    /// An item in the Gilded Rose inventory.
    /// 
    /// --- NOT TO BE MODIFIED ---
    /// </summary>
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
        /// Gets or sets the quality of the item.
        /// </summary>
        public int Quality { get; set; }
    }
}
