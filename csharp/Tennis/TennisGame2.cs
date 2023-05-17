public class TennisGame2 : ITennisGame
{
    private int p1point;
    private int p2point;
    private string p1res = "";
    private string p2res = "";
    private string player1Name;
    private string player2Name;

    private readonly string[] scoreDescriptions = { "Love", "Fifteen", "Thirty", "Forty" };

    private const string AdvantagePrefix = "Advantage ";
    private const string WinPrefix = "Win for ";

    public TennisGame2(string player1Name, string player2Name)
    {
        this.player1Name = player1Name;
        p1point = 0;
        this.player2Name = player2Name;
    }

    public string GetScore()
    {
        if (p1point == p2point)
        {
            return GetEqualScore();
        }
        else if (p1point >= 4 || p2point >= 4)
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
        if (p1point < 3)
        {
            return scoreDescriptions[p1point] + "-All";
        }
        else
        {
            return "Deuce";
        }
    }

    private string GetAdvantageOrWinScore()
    {
        if (p1point > p2point && p1point - p2point == 1)
        {
            return AdvantagePrefix + player1Name;
        }
        else if (p2point > p1point && p2point - p1point == 1)
        {
            return AdvantagePrefix + player2Name;
        }
        else if (p1point > p2point && p1point >= 4)
        {
            return WinPrefix + player1Name;
        }
        else if (p2point > p1point && p2point >= 4)
        {
            return WinPrefix + player2Name;
        }
        else
        {
            return "";
        }
    }

    private string GetNonEqualScore()
    {
        p1res = scoreDescriptions[p1point];
        p2res = scoreDescriptions[p2point];
        return p1res + "-" + p2res;
    }

    public void SetP1Score(int number)
    {
        for (int i = 0; i < number; i++)
        {
            P1Score();
        }
    }

    public void SetP2Score(int number)
    {
        for (int i = 0; i < number; i++)
        {
            P2Score();
        }
    }

    private void P1Score()
    {
        p1point++;
    }

    private void P2Score()
    {
        p2point++;
    }

    public void WonPoint(string player)
    {
        if (player == "player1")
        {
            P1Score();
        }
        else
        {
            P2Score();
        }
    }
}

