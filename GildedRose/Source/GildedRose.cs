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
				if (Items[i].Name != "Aged Brie")
				{
					if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
					{
						if (Items[i].Quality > 0) //-1 geral (o dobro qnd expirou)
						{
							if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
							{
								Items[i].Quality = Items[i].Quality - 1;
							}
						}
					}

					if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
					{
						Items[i].Quality = Items[i].Quality - Items[i].Quality;
					}
				}

				// +1 aged brie ( o dobro)
				if (Items[i].Name == "Aged Brie")
				{
					IncreaseItemQuality(i);
				}
			}
		}

		private void DecreaseSellIn(int i)
		{
			if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
			{
				Items[i].SellIn = Items[i].SellIn - 1;
			}
		}

		private void IncreaseSpecialItemQuality(int i)
		{
			if (Items[i].Name == "Aged Brie")
			{
				IncreaseItemQuality(i);
			}

			if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
			{
				IncreaseItemQuality(i);

				if (Items[i].SellIn < 11)
				{
					IncreaseItemQuality(i);
				}

				if (Items[i].SellIn < 6)
				{
					IncreaseItemQuality(i);
				}
			}
		}

		private void IncreaseItemQuality(int i)
		{
			if (Items[i].Quality < 50)
			{
				Items[i].Quality += 1;
			}
		}

		private void DecreaseCommonItemQuality(int i)
		{
			if (IsCommonItem(i) && Items[i].Quality > 0)
			{
				Items[i].Quality -= 1;
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
