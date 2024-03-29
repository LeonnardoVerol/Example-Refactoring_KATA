﻿using System.Collections.Generic;

namespace csharp
{
	public class GildedRose
	{
		IList<Item> Items;
		public GildedRose(IList<Item> Items)
		{
			this.Items = ItemFactory.UpdateItensType(Items);
		}

		public void UpdateQuality()
		{
			for (var i = 0; i < Items.Count; i++)
			{
				Items[i].DecreaseSellIn();
				Items[i].UpdateQuality();
			}
		}
	}

	class Common : Item
	{
		public override void UpdateQuality()
		{
			base.DecreaseQuality();

			if(this.SellIn < 0)
			{
				base.DecreaseQuality();
			}
		}
	}

	class AgedBrie : Item
	{
		public override void UpdateQuality()
		{
			base.IncreaseQuality();

			if (this.SellIn < 0)
			{
				base.IncreaseQuality();
			}
		}
	}

	class Sulfuras : Item
	{
		public override void UpdateQuality() { /* Do Nothing */ }
		public override void DecreaseSellIn() { /* Do Nothing */ }
	}

	class Backstage : Item
	{
		public override void UpdateQuality()
		{
			if(this.SellIn < 0)
			{
				this.Quality = 0;
				return;
			}

			base.IncreaseQuality();

			if (this.SellIn < 11)
			{
				base.IncreaseQuality();
			}

			if (this.SellIn < 6)
			{
				base.IncreaseQuality();
			}
		}
	}

	class ItemFactory
	{
		public static IList<Item> UpdateItensType(IList<Item> Items)
		{
			IList<Item> updatedItemListWithClasses = Items;

			for (var i = 0; i < Items.Count; i++)
			{
				if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
				{
					updatedItemListWithClasses[i] = new Backstage { Name = Items[i].Name, SellIn = Items[i].SellIn, Quality = Items[i].Quality };
				}
				else if (Items[i].Name == "Aged Brie")
				{
					updatedItemListWithClasses[i] = new AgedBrie { Name = Items[i].Name, SellIn = Items[i].SellIn, Quality = Items[i].Quality }; ;
				}
				else if (Items[i].Name == "Sulfuras, Hand of Ragnaros")
				{
					updatedItemListWithClasses[i] = new Sulfuras { Name = Items[i].Name, SellIn = Items[i].SellIn, Quality = Items[i].Quality }; ;
				}
				else
				{
					updatedItemListWithClasses[i] = new Common { Name = Items[i].Name, SellIn = Items[i].SellIn, Quality = Items[i].Quality }; ;
				}
			}

			return updatedItemListWithClasses;
		}
	}
}
