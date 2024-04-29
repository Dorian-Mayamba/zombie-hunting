using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame updat

    private static PlayerController instance;
    [SerializeField] private Player player;

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

    public void InitPlayer(string playerName)
    {
        player.PlayerName = playerName;
    }

    public void OnPlayerDead(Player player)
    {
        
    }

    public void UpdatePlayerScore(int point)
    {
        player.PlayerScore += point;
    }

    public static PlayerController GetInstance()
    {
        return instance;
    }
}
