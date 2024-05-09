using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderBoardPanelController : MonoBehaviour
{
    [SerializeField]
    private Transform LeaderBoardEntry;

    [SerializeField]
    private Transform LeaderBoardEntryContainer;
    // Start is called before the first frame update
    void Start()
    {
        LoadScore();   
    }

    private void LoadScore()
    {
        GameRecords gameRecords = GameRecords.GetInstance();
        List<PlayerScore> playerScores = gameRecords.GetPlayerScores();
        if(playerScores != null)
        {
            playerScores.Sort((a,b)=>a.CompareTo(b));
            DisplayScores(playerScores);
        }
    }

    private void DisplayScores(List<PlayerScore> playerScores)
    {
        int idx = 0;
        foreach(PlayerScore playerScore in playerScores)
        {
            
            int rank = idx + 1;
            string rankText;
            float entryHeight = 20f;
            switch(rank)
            {
                case 1:
                    rankText = rank + "ST";
                    break;
                case 2:
                    rankText = rank + "ND";
                    break;
                case 3:
                    rankText = rank + "RD";
                    break;
                default:
                    rankText = rank + "TH";
                    break;
            }
            
            Transform entryTransform = Instantiate(LeaderBoardEntry, LeaderBoardEntryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -entryHeight * idx);
            entryTransform.gameObject.SetActive(true);
            entryTransform.Find("RankText").GetComponent<TextMeshProUGUI>().text = rankText;
            entryTransform.Find("NameText").GetComponent<TextMeshProUGUI>().text = playerScore.playerName;
            entryTransform.Find("ScoreText").GetComponent<TextMeshProUGUI>().text = playerScore.score.ToString();
            idx++;
        }
    }
}

