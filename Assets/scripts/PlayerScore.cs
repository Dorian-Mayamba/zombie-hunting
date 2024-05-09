using System;

[Serializable]
public class PlayerScore: IComparable<PlayerScore>{
    public int score;
    public string playerName;

    public int CompareTo(PlayerScore other)
    {
       return score.CompareTo(other.Score);
    }

    public int Score{
        set{score=value;}
        get{return score;}
    }

    public string PlayerName{
        set{playerName = value;}
        get{return playerName;}
    }
}