namespace csharp
{
	public class Item
	{
		private const int MAX_QUALITY = 50;
		private const int MIN_QUALITY = 0;

		public string Name { get; set; }
		public int SellIn { get; set; }
		public int Quality { get; set; }

		public override string ToString()
		{
			return this.Name + ", " + this.SellIn + ", " + this.Quality;
		}

		public void IncreaseQualityByOne()
		{
			if(this.Quality < MAX_QUALITY)
			{
				this.Quality++;
			}
		}

		public void DecreaseQualityByOne()
		{
			if (this.Quality > MIN_QUALITY)
			{
				this.Quality--;
			}
		}
	}
}
