namespace Tennis
{
	public class TennisGame : ITennisGame
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

		public string GetScore()
		{			
			if ((player1point < 4 && player2point < 4) && (player1point + player2point < 6))
			{
				string[] gameCodeNames = { "Love", "Fifteen", "Thirty", "Forty" };

				if (player1point == player2point)
					return gameCodeNames[player1point] + "-All";
				else
					return gameCodeNames[player1point] + "-" + gameCodeNames[player2point];
			}
			else if (player1point == player2point)
				return "Deuce";
			else
			{
				string score = "";

				if (player1point > player2point && player2point >= 3)
				{
					score = "Advantage player1";
				}

				if (player2point > player1point && player1point >= 3)
				{
					score = "Advantage player2";
				}

				if (player1point >= 4 && player2point >= 0 && (player1point - player2point) >= 2)
				{
					score = "Win for player1";
				}
				if (player2point >= 4 && player1point >= 0 && (player2point - player1point) >= 2)
				{
					score = "Win for player2";
				}

				return score;
			}
		}

		public int GetTotalPoints()
		{
			return player1point + player2point;
		}
	}
}
