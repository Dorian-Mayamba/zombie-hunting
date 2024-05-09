using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    // Start is called before the first frame update
    private static Player instance;

    private int playerScore;

    private string playerName;

    [SerializeField] private HealthBar healthBar;

    [SerializeField] private const float MAX_HEALTH = 400f;
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

    public float Health{
        get{return health;}
        set{health = value;}
    }

    public void ResetScore()
    {
        PlayerScore = 0;
    }

    public void Init(string playerName)
    {
        health = MAX_HEALTH;

        PlayerName = playerName;
        PlayerScore = 0;
    }

    public GameObject Instantiate()
    {
        healthBar = GameController.GetInstance().healthBar;
        healthBar.InitHealth(MAX_HEALTH);
        return Instantiate(transform.gameObject);
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
        PlayerController.GetInstance().RaiseOnPlayerDead(this);
    }

    override public void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
        healthBar.TakeDamage(amount);
    }
}
