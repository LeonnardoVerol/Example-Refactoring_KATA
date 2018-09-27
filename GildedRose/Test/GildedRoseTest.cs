using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
	[TestFixture]
	public class GildedRoseTest
	{
		[Test]
		public void AgedBrie_IncreasesInQuality_TheOlderItGets()
		{
			IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 } };
			GildedRose app = new GildedRose(Items);
			for (var i = 0; i < 27; i++)
			{
				app.UpdateQuality();
			}

			Assert.Greater(Items[0].Quality, 0);
		}

		[Test]
		public void NoItem_ShouldHaveMoreThan_50InQuality()
		{
			IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 } };
			GildedRose app = new GildedRose(Items);
			for (var i = 0; i < 31; i++)
			{
				app.UpdateQuality();
			}

			Assert.IsTrue(Items[0].Quality <= 50);
		}

		[Test]
		public void Item_ShouldDegradeSellInAndQuality_EachDay()
		{
			IList<Item> Items = new List<Item> {
				new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
				new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7}
			};
			GildedRose app = new GildedRose(Items);

			app.UpdateQuality();

			Assert.IsTrue(Items[0].Quality < 20 && Items[1].Quality < 7);
		}

		[Test]
		public void NoItem_ShouldHaveLessThan_0InQuality()
		{
			IList<Item> Items = new List<Item> {
				new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
				new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7}
			};
			GildedRose app = new GildedRose(Items);

			for (var i = 0; i < 31; i++)
			{
				app.UpdateQuality();
			}

			Assert.IsTrue(Items[0].Quality >= 0 && Items[1].Quality >= 0);
		}

		[Test]
		public void OnceTheSellByDateHasPassed_QualityDegrades_TwiceAsFast()
		{
			IList<Item> Items = new List<Item> {
				new Item {Name = "+5 Dexterity Vest", SellIn = 0, Quality = 10}
			};
			GildedRose app = new GildedRose(Items);

			app.UpdateQuality();

			Assert.AreEqual(Items[0].Quality, 8);
		}

		[Test]
		public void BackstagePass_ShouldBe0_AfterSellInDate()
		{
			IList<Item> Items = new List<Item> {
				new Item
				{
				    Name = "Backstage passes to a TAFKAL80ETC concert",
				    SellIn = 1,
				    Quality = 20
				}
			};
			GildedRose app = new GildedRose(Items);

			for (var i = 0; i < 2; i++)
			{
				app.UpdateQuality();
			}

			Assert.AreEqual(Items[0].Quality, 0);
		}

		[Test]
		public void BackstagePass_QualityIncreasesBy3_When5DaysOrLess()
		{
			IList<Item> Items = new List<Item> {
				new Item
				{
				    Name = "Backstage passes to a TAFKAL80ETC concert",
				    SellIn = 4,
				    Quality = 20
				}
			};
			GildedRose app = new GildedRose(Items);

			for (var i = 0; i < 2; i++)
			{
				app.UpdateQuality();
			}

			Assert.AreEqual(Items[0].Quality, 26);
		}

		[Test]
		public void BackstagePass_QualityIncreasesBy2_When10DaysOrLess()
		{
			IList<Item> Items = new List<Item> {
				new Item
				{
				    Name = "Backstage passes to a TAFKAL80ETC concert",
				    SellIn = 9,
				    Quality = 20
				}
			};
			GildedRose app = new GildedRose(Items);

			for (var i = 0; i < 2; i++)
			{
				app.UpdateQuality();
			}

			Assert.AreEqual(Items[0].Quality, 24);
		}
	}
}
