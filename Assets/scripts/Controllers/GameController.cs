using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.InputSystem.LowLevel;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    

    private static GameController instance;

    private PlayerController playerManager;

    public delegate void GameStateChange(GameState state);

    public static event GameStateChange ChangeGameState;
    

    private void Awake() {
        if(instance != this || instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(transform.gameObject);
    }

    public static GameController GetInstance()
    {
        return instance;
    }

    void Start()
    {
        playerManager = PlayerController.GetInstance();
    }

    public void OnGameStateChange(GameState state)
    {
        switch(state)
        {
            case GameState.GAME_START:
                //handleGameStart
                break;
            case GameState.GAME_PAUSE:
                //handleGamePause
                break;
            case GameState.GAME_OVER:
                //handleGameOver
                break;
        }
    }

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        ChangeGameState+=OnGameStateChange;
    }

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable()
    {
        ChangeGameState-=OnGameStateChange;
    }


    public enum GameState{
        GAME_OVER,
        GAME_START,
        GAME_PAUSE,
    }

    public void RaiseGameStateChange(GameState gameState)
    {
        ChangeGameState?.Invoke(gameState);
    }

    

// Update is called once per frame
    
}
