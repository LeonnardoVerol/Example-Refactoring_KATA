namespace Tennis
{
	public class TennisGame
	{
		private int player1point;
		private int player2point;
		
		private string player1Name;
		private string player2Name;

		public TennisGame(string player1Name, string player2Name)
		{
			this.player1Name = player1Name;
			this.player2Name = player2Name;
		}

		public void WonPoint(string playerName)
		{
			if (playerName == "player1")
				this.player1point++;
			else
				this.player2point++;
		}
	}
}
