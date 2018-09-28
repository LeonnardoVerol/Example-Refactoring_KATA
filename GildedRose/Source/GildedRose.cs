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

				//Quality +1 e backstage especial
				IncreaseSpecialItemQuality(i);

				// sellin -1 geral
				if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
				{
					Items[i].SellIn = Items[i].SellIn - 1;
				}

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
						if (Items[i].Quality < 50)
						{
							Items[i].Quality = Items[i].Quality + 1;
						}
					}
				}
			}
		}

		private void IncreaseSpecialItemQuality(int i)
		{
			if (Items[i].Name == "Aged Brie" || Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
			{
				if (Items[i].Quality < 50)
				{
					Items[i].Quality = Items[i].Quality + 1;

					if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
					{
						if (Items[i].SellIn < 11)
						{
							if (Items[i].Quality < 50)
							{
								Items[i].Quality = Items[i].Quality + 1;
							}
						}

						if (Items[i].SellIn < 6)
						{
							if (Items[i].Quality < 50)
							{
								Items[i].Quality = Items[i].Quality + 1;
							}
						}
					}
				}
			}
		}

		private void DecreaseCommonItemQuality(int i)
		{
			if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
			{
				if (Items[i].Quality > 0)
				{
					if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
					{
						Items[i].Quality = Items[i].Quality - 1;
					}
				}
			}
		}
	}
}
