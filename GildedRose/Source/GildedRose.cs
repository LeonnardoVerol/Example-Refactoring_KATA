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
				Items[i].DecreaseQualityByOne();

				IncreaseSpecialItemQuality(i);

				Items[i].DecreaseSellInByOne();

				ChangeExpiredItensQuality(i);
			}
		}

		private void ChangeExpiredItensQuality(int i)
		{
			if (Items[i].SellIn < 0)
			{
				Items[i].DecreaseQualityByOne();

				if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
				{
					Items[i].Quality = 0;
				}

				if (Items[i].Name == "Aged Brie")
				{
					Items[i].IncreaseQualityByOne();
				}
			}
		}

		private void IncreaseSpecialItemQuality(int i)
		{
			if (Items[i].Name == "Aged Brie")
			{
				Items[i].IncreaseQualityByOne();
			}

			if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
			{
				Items[i].IncreaseQualityByOne();

				if (Items[i].SellIn < 11)
				{
					Items[i].IncreaseQualityByOne();
				}

				if (Items[i].SellIn < 6)
				{
					Items[i].IncreaseQualityByOne();
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
		public override void DecreaseQualityByOne() { /* Do Nothing */ }
	}

	class Sulfuras : Item
	{
		public override void DecreaseQualityByOne() { /* Do Nothing */ }
		public override void DecreaseSellInByOne() { /* Do Nothing */ }
	}

	class Backstage : Item
	{
		public override void DecreaseQualityByOne() { /* Do Nothing */ }
	}
}
