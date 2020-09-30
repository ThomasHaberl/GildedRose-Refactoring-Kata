using GildedRoseKata;
using System.Collections.Generic;
using Xunit;

namespace GildedRoseKataTests
{
    public class GildedRoseTest
    {
        #region Regular Items

        [Fact]
        public void UpdateQuality_WhenItemIsRegular_SellInDecreases()
        {
            IList<Item> items = new List<Item> {
                new Item { Name = "foo", SellIn = 1, Quality = 10 },
            };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(0, items[0].SellIn);

            app.UpdateQuality();

            Assert.Equal(-1, items[0].SellIn);
        }

        [Fact]
        public void UpdateQuality_WhenItemIsRegular_QualityDegradesBeforeExpiryDate()
        {
            IList<Item> items = new List<Item> {
                new Item { Name = "foo", SellIn = 2, Quality = 2 },
                new Item { Name = "bar", SellIn = 10, Quality = 25 },
                new Item { Name = "baz", SellIn = 20, Quality = 50 },
            };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(1, items[0].Quality);
            Assert.Equal(24, items[1].Quality);
            Assert.Equal(49, items[2].Quality);

            app.UpdateQuality();

            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenItemIsRegular_QualityDegradesAfterExpiryDate()
        {
            IList<Item> items = new List<Item> {
                new Item { Name = "foo", SellIn = 0, Quality = 10 },
            };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(8, items[0].Quality);

            app.UpdateQuality();

            Assert.Equal(6, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenItemIsRegular_QualityLowerLimit()
        {
            IList<Item> items = new List<Item> {
                new Item { Name = "foo", SellIn = 10, Quality = 0 },
                new Item { Name = "bar", SellIn = 0, Quality = 0 },
                new Item { Name = "baz", SellIn = -1, Quality = 0 },
            };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(0, items[0].Quality);
            Assert.Equal(0, items[1].Quality);
            Assert.Equal(0, items[2].Quality);
        }

        #endregion


        #region Aged Brie Items

        [Fact]
        public void UpdateQuality_WhenItemIsAgedBrie_SellInDecreases()
        {
            IList<Item> items = new List<Item> {
                new Item { Name = "Aged Brie", SellIn = 1, Quality = 10 },
            };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(0, items[0].SellIn);

            app.UpdateQuality();

            Assert.Equal(-1, items[0].SellIn);
        }

        [Fact]
        public void UpdateQuality_WhenItemIsAgedBrie_QualityIncreasesBeforeExpiryDate()
        {
            IList<Item> items = new List<Item> {
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new Item { Name = "Aged Brie", SellIn = 10, Quality = 25 },
                new Item { Name = "Aged Brie", SellIn = 20, Quality = 48 },
            };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(1, items[0].Quality);
            Assert.Equal(26, items[1].Quality);
            Assert.Equal(49, items[2].Quality);

            app.UpdateQuality();

            Assert.Equal(50, items[2].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenItemIsAgedBrie_QualityIncreasesAfterExpiryDate()
        {
            IList<Item> items = new List<Item> {
                new Item { Name = "Aged Brie", SellIn = 0, Quality = 10 },
            };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(12, items[0].Quality);

            app.UpdateQuality();

            Assert.Equal(14, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenItemIsAgedBrie_QualityUpperLimit()
        {
            IList<Item> items = new List<Item> {
                new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 },
                new Item { Name = "Aged Brie", SellIn = 0, Quality = 50 },
                new Item { Name = "Aged Brie", SellIn = -1, Quality = 50 },
            };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(50, items[0].Quality);
            Assert.Equal(50, items[1].Quality);
            Assert.Equal(50, items[2].Quality);
        }

        #endregion


        #region Legendary Items

        [Fact]
        public void UpdateQuality_WhenItemIsLegendary_SellInConstant()
        {
            IList<Item> items = new List<Item> {
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 10 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 10 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 10 },
            };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(10, items[0].SellIn);
            Assert.Equal(0, items[1].SellIn);
            Assert.Equal(-1, items[2].SellIn);
        }

        [Fact]
        public void UpdateQuality_WhenItemIsLegendary_QualityConstantBeforeExpiryDate()
        {
            IList<Item> items = new List<Item> {
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 2, Quality = 0 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 25 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 20, Quality = 50 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 30, Quality = 80 },
            };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(0, items[0].Quality);
            Assert.Equal(25, items[1].Quality);
            Assert.Equal(50, items[2].Quality);
            Assert.Equal(80, items[3].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenItemIsLegendary_QualityConstantAfterExpiryDate()
        {
            IList<Item> items = new List<Item> {
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 0 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 25 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -2, Quality = 50 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -10, Quality = 80 },
            };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(0, items[0].Quality);
            Assert.Equal(25, items[1].Quality);
            Assert.Equal(50, items[2].Quality);
            Assert.Equal(80, items[3].Quality);
        }

        #endregion


        #region Backstage Pass Items

        [Fact]
        public void UpdateQuality_WhenItemIsBackstagePass_SellInDecreases()
        {
            IList<Item> items = new List<Item> {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 10 },
            };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(0, items[0].SellIn);

            app.UpdateQuality();

            Assert.Equal(-1, items[0].SellIn);
        }

        [Fact]
        public void UpdateQuality_WhenItemIsBackstagePass_QualityIncreasesBeforeExpiryDate()
        {
            IList<Item> items = new List<Item> {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 20, Quality = 0 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 30, Quality = 20 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 40, Quality = 48 },
            };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(1, items[0].Quality);
            Assert.Equal(21, items[1].Quality);
            Assert.Equal(49, items[2].Quality);

            app.UpdateQuality();

            Assert.Equal(50, items[2].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenItemIsBackstagePass_QualityIncreaseDoublesBeforeExpiryDate()
        {
            IList<Item> items = new List<Item> {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 6, Quality = 48 },
            };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(12, items[0].Quality);
            Assert.Equal(50, items[1].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenItemIsBackstagePass_QualityIncreaseTriplesBeforeExpiryDate()
        {
            IList<Item> items = new List<Item> {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 47 },
            };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(13, items[0].Quality);
            Assert.Equal(50, items[1].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenItemIsBackstagePass_QualityUpperLimit()
        {
            IList<Item> items = new List<Item> {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 20, Quality = 50 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 48 },
            };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(50, items[0].Quality);
            Assert.Equal(50, items[1].Quality);
            Assert.Equal(50, items[2].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenItemIsBackstagePass_QualityZeroOnExpiryDate()
        {
            IList<Item> items = new List<Item> {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 },
            };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(0, items[0].Quality);
        }

        #endregion


        #region Conjured Items (not implemented)
        /*
        [Fact]
        public void UpdateQuality_WhenItemIsConjured_SellInDecreases()
        {
            IList<Item> items = new List<Item> {
                new Item { Name = "Conjured Mana Cake", SellIn = 1, Quality = 10 },
            };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(0, items[0].SellIn);

            app.UpdateQuality();

            Assert.Equal(-1, items[0].SellIn);
        }

        [Fact]
        public void UpdateQuality_WhenItemIsConjured_QualityDegradesBeforeExpiryDate()
        {
            IList<Item> items = new List<Item> {
                new Item { Name = "Conjured Mana Cake", SellIn = 2, Quality = 4 },
                new Item { Name = "Conjured Mana Cake", SellIn = 10, Quality = 25 },
                new Item { Name = "Conjured Mana Cake", SellIn = 20, Quality = 50 },
            };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(2, items[0].Quality);
            Assert.Equal(23, items[1].Quality);
            Assert.Equal(48, items[2].Quality);

            app.UpdateQuality();

            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenItemIsConjured_QualityDegradesAfterExpiryDate()
        {
            IList<Item> items = new List<Item> {
                new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 10 },
            };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(6, items[0].Quality);

            app.UpdateQuality();

            Assert.Equal(2, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenItemIsConjured_QualityLowerLimit()
        {
            IList<Item> items = new List<Item> {
                new Item { Name = "Conjured Mana Cake", SellIn = 10, Quality = 0 },
                new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 0 },
                new Item { Name = "Conjured Mana Cake", SellIn = -1, Quality = 0 },
            };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(0, items[0].Quality);
            Assert.Equal(0, items[1].Quality);
            Assert.Equal(0, items[2].Quality);
        }
        */
        #endregion
    }
}