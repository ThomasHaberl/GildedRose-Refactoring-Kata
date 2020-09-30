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
                ItemFactory.CreateItem("foo", 1, 10),
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
                ItemFactory.CreateItem("foo", 2, 2),
                ItemFactory.CreateItem("bar", 10, 25),
                ItemFactory.CreateItem("baz", 20, 50),
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
                ItemFactory.CreateItem("foo", 0, 10),
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
                ItemFactory.CreateItem("foo", 10, 0),
                ItemFactory.CreateItem("bar", 0, 0),
                ItemFactory.CreateItem("baz", -1, 0),
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
                ItemFactory.CreateItem("Aged Brie", 1, 10),
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
                ItemFactory.CreateItem("Aged Brie", 2, 0),
                ItemFactory.CreateItem("Aged Brie", 10, 25),
                ItemFactory.CreateItem("Aged Brie", 20, 48),
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
                ItemFactory.CreateItem("Aged Brie", 0, 10),
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
                ItemFactory.CreateItem("Aged Brie", 10, 50),
                ItemFactory.CreateItem("Aged Brie", 0, 50),
                ItemFactory.CreateItem("Aged Brie", -1, 50),
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
                ItemFactory.CreateItem("Sulfuras, Hand of Ragnaros", 10, 10),
                ItemFactory.CreateItem("Sulfuras, Hand of Ragnaros", 0, 10),
                ItemFactory.CreateItem("Sulfuras, Hand of Ragnaros", -1, 10),
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
                ItemFactory.CreateItem("Sulfuras, Hand of Ragnaros", 2, 0),
                ItemFactory.CreateItem("Sulfuras, Hand of Ragnaros", 10, 25),
                ItemFactory.CreateItem("Sulfuras, Hand of Ragnaros", 20, 50),
            };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(0, items[0].Quality);
            Assert.Equal(25, items[1].Quality);
            Assert.Equal(50, items[2].Quality);
        }

        [Fact]
        public void UpdateQuality_WhenItemIsLegendary_QualityConstantAfterExpiryDate()
        {
            IList<Item> items = new List<Item> {
                ItemFactory.CreateItem("Sulfuras, Hand of Ragnaros", 0, 0),
                ItemFactory.CreateItem("Sulfuras, Hand of Ragnaros", -1, 25),
                ItemFactory.CreateItem("Sulfuras, Hand of Ragnaros", -2, 50),
            };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(0, items[0].Quality);
            Assert.Equal(25, items[1].Quality);
            Assert.Equal(50, items[2].Quality);
        }

        #endregion


        #region Backstage Pass Items

        [Fact]
        public void UpdateQuality_WhenItemIsBackstagePass_SellInDecreases()
        {
            IList<Item> items = new List<Item> {
                ItemFactory.CreateItem("Backstage passes to a TAFKAL80ETC concert", 1, 10),
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
                ItemFactory.CreateItem("Backstage passes to a TAFKAL80ETC concert", 11, 0),
                ItemFactory.CreateItem("Backstage passes to a TAFKAL80ETC concert", 20, 20),
                ItemFactory.CreateItem("Backstage passes to a TAFKAL80ETC concert", 30, 48),
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
                ItemFactory.CreateItem("Backstage passes to a TAFKAL80ETC concert", 10, 10),
                ItemFactory.CreateItem("Backstage passes to a TAFKAL80ETC concert", 6, 48),
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
                ItemFactory.CreateItem("Backstage passes to a TAFKAL80ETC concert", 5, 10),
                ItemFactory.CreateItem("Backstage passes to a TAFKAL80ETC concert", 1, 47),
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
                ItemFactory.CreateItem("Backstage passes to a TAFKAL80ETC concert", 20, 50),
                ItemFactory.CreateItem("Backstage passes to a TAFKAL80ETC concert", 10, 49),
                ItemFactory.CreateItem("Backstage passes to a TAFKAL80ETC concert", 5, 48),
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
                ItemFactory.CreateItem("Backstage passes to a TAFKAL80ETC concert", 0, 10),
            };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(0, items[0].Quality);
        }

        #endregion


        #region Conjured Items (not implemented)
        
        [Fact]
        public void UpdateQuality_WhenItemIsConjured_SellInDecreases()
        {
            IList<Item> items = new List<Item> {
                ItemFactory.CreateItem("Conjured Mana Cake", 1, 10),
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
                ItemFactory.CreateItem("Conjured Mana Cake", 2, 4),
                ItemFactory.CreateItem("Conjured Mana Cake", 10, 25),
                ItemFactory.CreateItem("Conjured Mana Cake", 20, 50),
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
                ItemFactory.CreateItem("Conjured Mana Cake", 0, 10),
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
                ItemFactory.CreateItem("Conjured Mana Cake", 10, 0),
                ItemFactory.CreateItem("Conjured Mana Cake", 0, 0),
                ItemFactory.CreateItem("Conjured Mana Cake", -1, 0),
            };
            GildedRose app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(0, items[0].Quality);
            Assert.Equal(0, items[1].Quality);
            Assert.Equal(0, items[2].Quality);
        }
        
        #endregion
    }
}