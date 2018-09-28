using System;
using System.Collections.Generic;

namespace csharp
{
	public class GildedRose
	{
		IList<Item> Items;
		public GildedRose(IList<Item> Items)
		{
			this.Items = Items;
		}

		public void UpdateQuality()
		{
			UpdateItensType();

			for (var i = 0; i < Items.Count; i++)
			{
				Items[i].DecreaseQuality();

				IncreaseSpecialItemQuality(i);

				Items[i].DecreaseSellIn();

				ChangeExpiredItensQuality(i);
			}
		}

		private void ChangeExpiredItensQuality(int i)
		{
			if (Items[i].SellIn < 0)
			{
				Items[i].DecreaseQuality();

				if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
				{
					Items[i].Quality = 0;
				}

				if (Items[i].Name == "Aged Brie")
				{
					Items[i].IncreaseQuality();
				}
			}
		}

		private void IncreaseSpecialItemQuality(int i)
		{
			if (Items[i].Name == "Aged Brie")
			{
				Items[i].IncreaseQuality();
			}

			if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
			{
				Items[i].IncreaseQuality();

				if (Items[i].SellIn < 11)
				{
					Items[i].IncreaseQuality();
				}

				if (Items[i].SellIn < 6)
				{
					Items[i].IncreaseQuality();
				}
			}
		}

		private void UpdateItensType()
		{
			for (var i = 0; i < Items.Count; i++)
			{
				if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
				{
					Items[i] = new Backstage { Name = Items[i].Name, SellIn = Items[i].SellIn, Quality = Items[i].Quality };
				}
				else if (Items[i].Name == "Aged Brie")
				{
					Items[i] = new AgedBrie { Name = Items[i].Name, SellIn = Items[i].SellIn, Quality = Items[i].Quality }; ;
				}
				else if (Items[i].Name == "Sulfuras, Hand of Ragnaros")
				{
					Items[i] = new Sulfuras { Name = Items[i].Name, SellIn = Items[i].SellIn, Quality = Items[i].Quality }; ;
				}
				else
				{
					Items[i] = new Common { Name = Items[i].Name, SellIn = Items[i].SellIn, Quality = Items[i].Quality }; ;
				}
			}
		}
	}

	class Common : Item
	{

	}

	class AgedBrie : Item
	{
		public override void DecreaseQuality() { /* Do Nothing */ }
	}

	class Sulfuras : Item
	{
		public override void DecreaseQuality() { /* Do Nothing */ }
		public override void DecreaseSellIn() { /* Do Nothing */ }
	}

	class Backstage : Item
	{
		public override void DecreaseQuality() { /* Do Nothing */ }
	}
}
