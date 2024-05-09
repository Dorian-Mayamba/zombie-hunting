using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    private static GameController instance;

    private PlayerController playerManager;

    private ZombieController zombieController;

    [SerializeField]
    private UIController uIController;

    [SerializeField]
    public Transform[] spawnPoints;

    [SerializeField]
    public HealthBar healthBar;

    public delegate void GameStateChange(GameState state);

    public static event GameStateChange ChangeGameState;

    [SerializeField] TextMeshProUGUI playerScoreText, playerNameText;
    

    private void Awake() {
        if(instance != this || instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(transform.gameObject);
    }

    private void Update() {
        
    }

    public static GameController GetInstance()
    {
        return instance;
    }

    void Start()
    {
        playerManager = PlayerController.GetInstance();
        zombieController = ZombieController.GetInstance();
        ChangeGameState?.Invoke(GameState.GAME_START);
    }

    public void OnGameStateChange(GameState state)
    {
        switch(state)
        {
            case GameState.GAME_START:
                HandleGameStart();
                //handleGameStart
                break;
            case GameState.GAME_PAUSE:
                HandleGamePause();
                //HandleGame pause
                break;
            case GameState.GAME_OVER:
                //handleGameOver
                HandleGameOver();
                break;
        }
    }

    private void HandleGameStart()
    {
        //Instantiate players and enemies
        playerManager.InstantiatePlayer();
        playerNameText.text = playerManager.GetPlayer().PlayerName;
        playerScoreText.text = playerManager.GetPlayer().PlayerScore.ToString();
        zombieController.SpawEnnemies(10);
    }

    private void HandleGameOver()
    {
        Player player = playerManager.GetPlayer();
        GameRecords records = GameRecords.GetInstance();
        records.SavePlayerScore(player.PlayerName,player.PlayerScore);
        Destroy(transform.gameObject);
        SceneManager.LoadSceneAsync("GameOverScene");
    }

    private void HandleGamePause()
    {
        
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

    public void RestartGame()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(scene);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadSceneAsync("MenuScene");
    }

    internal void UpdatePlayerScore(int playerScore)
    {
        playerScoreText.text = "Score: " + playerScore;
    }
}
