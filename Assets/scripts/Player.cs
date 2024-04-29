using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    // Start is called before the first frame update

    private static Player instance;

    private int playerScore;

    private string playerName;
    private void Awake() {
        if(instance != this || instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(transform.gameObject);
        playerScore = 0;
    }

    public string PlayerName
    {
        set{playerName = value;}
        get{return playerName;}
    }

    public int PlayerScore
    {
        set{playerScore = value;}
        get{return playerScore;}
    }
    
   
    public static Player GetInstance()
    {
        return instance;
    }

    protected override void Die()
    {
        
        //Notify playerManager
        eventManager.RaiseOnPlayerDead(this);
        
    }
}
