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
			for (var i = 0; i < Items.Count; i++)
			{
				// Quality -1 geral
				DecreaseCommonItemQuality(i);

				// Quality +1 e backstage especial
				IncreaseSpecialItemQuality(i);

				// sellin -1 geral
				DecreaseSellIn(i);

				// Expired Itens
				ChangeExpiredItensQuality(i);
			}
		}

		private void ChangeExpiredItensQuality(int i)
		{
			if (Items[i].SellIn < 0)
			{
				DecreaseCommonItemQuality(i);
				
				if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
				{
					Items[i].Quality = 0;
				}

				// +1 aged brie ( o dobro)
				if (Items[i].Name == "Aged Brie")
				{
					Items[i].IncreaseQualityByOne();
				}
			}
		}

		private void DecreaseSellIn(int i)
		{
			if (Items[i].Name == "Sulfuras, Hand of Ragnaros")
				return;

			Items[i].SellIn -= 1;
			
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

		private void DecreaseCommonItemQuality(int i)
		{
			if (IsCommonItem(i))
			{
				Items[i].DecreaseQualityByOne();
			}
		}

		private bool IsCommonItem(int i)
		{
			if (Items[i].Name == "Aged Brie"
			|| Items[i].Name == "Backstage passes to a TAFKAL80ETC concert"
			|| Items[i].Name == "Sulfuras, Hand of Ragnaros")
				return false;

			return true;
		}
	}
}
