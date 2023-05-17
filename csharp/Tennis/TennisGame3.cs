namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private int player1Points;
        private int player2Points;
        private string player1Name;
        private string player2Name;

        public static readonly string[] POINTS_NAMES = { "Love", "Fifteen", "Thirty", "Forty" };
        public const string DEUCE = "Deuce";
        public const string ADVANTAGE_PREFIX = "Advantage ";
        public const string WIN_PREFIX = "Win for ";

        public TennisGame3(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            if (IsNotYetEndgame())
            {
                return GetRegularScore();
            }
            else
            {
                if (player1Points == player2Points)
                {
                    return DEUCE;
                }
                else
                {
                    string leader = player1Points > player2Points ? player1Name : player2Name;
                    return GetAdvantageOrWinScore(leader);
                }
            }
        }

        private bool IsNotYetEndgame()
        {
            return (player1Points < 4 && player2Points < 4) && (player1Points + player2Points < 6);
        }

        private string GetRegularScore()
        {
            if (player1Points == player2Points)
            {
                return POINTS_NAMES[player1Points] + "-All";
            }
            else
            {
                return POINTS_NAMES[player1Points] + "-" + POINTS_NAMES[player2Points];
            }
        }

        private string GetAdvantageOrWinScore(string leader)
        {
            int pointDifference = player1Points - player2Points;
            bool isAdvantage = pointDifference * pointDifference == 1;
            if (isAdvantage)
            {
                return ADVANTAGE_PREFIX + leader;
            }
            else
            {
                return WIN_PREFIX + leader;
            }
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
            {
                player1Points += 1;
            }
            else
            {
                player2Points += 1;
            }
        }
    }
}

