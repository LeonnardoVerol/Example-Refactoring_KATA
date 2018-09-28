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

		public void IncreaseQualityByOne()
		{
			if(this.Quality < Item.MAX_QUALITY)
			{
				this.Quality++;
			}
		}

		public virtual void DecreaseQualityByOne()
		{
			if (this.Quality > Item.MIN_QUALITY)
			{
				this.Quality--;
			}
		}
	}
}
