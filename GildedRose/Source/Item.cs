namespace csharp
{
	public class Item
	{
		protected const int MAX_QUALITY = 50;
		protected const int MIN_QUALITY = 0;

		public string Name { get; set; }
		public int SellIn { get; set; }
		public int Quality { get; set; }

		public override string ToString()
		{
			return this.Name + ", " + this.SellIn + ", " + this.Quality;
		}

		public virtual void IncreaseQuality()
		{
			if(this.Quality < Item.MAX_QUALITY)
			{
				this.Quality++;
			}
		}

		public virtual void DecreaseQuality()
		{
			if (this.Quality > Item.MIN_QUALITY)
			{
				this.Quality--;
			}
		}

		public virtual void DecreaseSellIn()
		{
			this.SellIn--;
		}
	}
}
