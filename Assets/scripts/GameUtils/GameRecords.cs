using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameRecords
{
    private static GameRecords instance;
    private PlayerScores playerScores;

    private const string GAME_STATE_FILE = "gamestate.json";

    private GameRecords()
    {
        string playerScoresJson = PlayerPrefs.GetString("playerScores");
        Debug.Log("Loaded player scores JSON: " + playerScoresJson);
        if (!string.IsNullOrEmpty(playerScoresJson))
        {
            playerScores = JsonUtility.FromJson<PlayerScores>(playerScoresJson);
        }
        else
        {
            Debug.Log("No existing scores. Creating new player score list.");
            playerScores = new PlayerScores { playerScores = new List<PlayerScore>() };
        }

    }

    public static GameRecords GetInstance()
    {
        if (instance == null)
        {
            instance = new GameRecords();
        }
        return instance;
    }


    public void SavePlayerScore(string playerName, int playerScore)
    {
        AddOrUpdatePlayerScore(playerName, playerScore, playerScores.playerScores);
        string playerScoresJson = JsonUtility.ToJson(playerScores);
        Debug.Log("Saving player score " + playerScoresJson);
        PlayerPrefs.SetString("playerScores", playerScoresJson);
        PlayerPrefs.Save();
    }

    public List<PlayerScore> GetPlayerScores()
    {
        return playerScores.playerScores;
    }

    public void AddOrUpdatePlayerScore(string playerName, int playerScore, List<PlayerScore> playerScores)
    {
        var foundPlayerScore = playerScores.Find(p => p.PlayerName == playerName);
        if (foundPlayerScore != null)
        {
            foundPlayerScore.Score = playerScore;
        }
        else
        {
            playerScores.Add(new PlayerScore { PlayerName = playerName, Score = playerScore });
        }

    }

    public void saveGameState(Player currentPlayer)
    {
        GameState gameState = new GameState{playerScore = currentPlayer.PlayerScore,
        playerName = currentPlayer.PlayerName, playerHealth = currentPlayer.Health};
        string gameStateJson = JsonUtility.ToJson(gameState);
        WriteToFile(gameStateJson, GAME_STATE_FILE);
    }

    private void WriteToFile(string json, string filename)
    {
        string path = Path.Combine(Application.persistentDataPath, filename);
        File.WriteAllText(path, json);
        Debug.Log("Game state saved to " + path);
    }

    public GameState LoadGameState(string filename)
    {
        string path = Path.Combine(Application.persistentDataPath, filename);
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameState gameState = JsonUtility.FromJson<GameState>(json);
            return gameState;
        }
        return null;
    }

    [Serializable]
    private class PlayerScores
    {
        public List<PlayerScore> playerScores;
    }

   









}