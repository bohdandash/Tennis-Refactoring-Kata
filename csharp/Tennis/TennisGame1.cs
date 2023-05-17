namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private const int MaxScoreForDeuce = 3;
        private const string Deuce = "Deuce";
        private const string Advantage = "Advantage";
        private const string Win = "Win for";
        private const string All = "-All";
        private const string Separator = "-";
        private const string Love = "Love";
        private const string Fifteen = "Fifteen";
        private const string Thirty = "Thirty";
        private const string Forty = "Forty";

        private int m_score1 = 0;
        private int m_score2 = 0;
        private string player1Name;
        private string player2Name;

        private readonly string[] scoreDescriptions = { Love, Fifteen, Thirty, Forty };

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                m_score1++;
            else
                m_score2++;
        }

        public string GetScore()
        {
            if (m_score1 == m_score2)
            {
                return GetEqualScore();
            }
            else if (m_score1 >= 4 || m_score2 >= 4)
            {
                return GetAdvantageOrWinScore();
            }
            else
            {
                return GetNonEqualScore();
            }
        }

        private string GetEqualScore()
        {
            if (m_score1 < MaxScoreForDeuce)
            {
                return scoreDescriptions[m_score1] + All;
            }
            else
            {
                return Deuce;
            }
        }

        private string GetAdvantageOrWinScore()
        {
            var minusResult = m_score1 - m_score2;
            if (minusResult == 1)
            {
                return Advantage + " " + player1Name;
            }
            else if (minusResult == -1)
            {
                return Advantage + " " + player2Name;
            }
            else if (minusResult >= 2)
            {
                return Win + " " + player1Name;
            }
            else
            {
                return Win + " " + player2Name;
            }
        }

        private string GetNonEqualScore()
        {
            return scoreDescriptions[m_score1] + Separator + scoreDescriptions[m_score2];
        }
    }

}
