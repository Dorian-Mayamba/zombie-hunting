using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame updat

    private static PlayerController instance;
    [SerializeField] private Player player;

    private delegate void PlayerDead(Player player);

    private static event PlayerDead OnPlayerDeath;

    public GameObject playerInstance;

    public GameObject playerBarGo;

    private void Awake() {
        if (instance == null || (instance != null && instance != this))
        {
            instance = this;
        }
        DontDestroyOnLoad(transform.gameObject);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Check for player death
    }

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        OnPlayerDeath+=OnPlayerDead;
    }

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable()
    {
        OnPlayerDeath-=OnPlayerDeath;
    }

    public void InitPlayer(string playerName)
    {
        player.Init(playerName);
    }

    public void OnPlayerDead(Player player)
    {
        GameController.GetInstance().RaiseGameStateChange(GameController.GameState.GAME_OVER);
    }

    public void UpdatePlayerScore(int point)
    {
        player.PlayerScore += point;
        GameController.GetInstance().UpdatePlayerScore(player.PlayerScore);
    }

    public void ResetPlayerScore()
    {
        player.ResetScore();
    }
    public static PlayerController GetInstance()
    {
        return instance;
    }

    public Player GetPlayer()
    {
        return player;
    }

    public void InstantiatePlayer()
    {
       playerInstance =  player.Instantiate();
    }

    public void RaiseOnPlayerDead(Player player)
    {
        OnPlayerDeath?.Invoke(player);
    }
}
