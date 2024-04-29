using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject optionMenuPanel;
    [SerializeField] private GameObject leaderBoardPanel;
    [SerializeField] private GameObject nameEntryPanel;    // Start is called before the first frame update

    public void ToggleMainMenu()
    {
        mainMenuPanel.SetActive(true);
        optionMenuPanel.SetActive(false);
        leaderBoardPanel.SetActive(false);
        nameEntryPanel.SetActive(false);
    }

    public void ToggleOptionMenu()
    {
        optionMenuPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
        leaderBoardPanel.SetActive(false);
        nameEntryPanel.SetActive(false);
    }

    public void ToggleLeaderPanel()
    {
        mainMenuPanel.SetActive(false);
        optionMenuPanel.SetActive(false);
        leaderBoardPanel.SetActive(true);
        nameEntryPanel.SetActive(false);
    }

    public void ToggleNameEntryPanel()
    {
        nameEntryPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
        optionMenuPanel.SetActive(false);
        leaderBoardPanel.SetActive(false);
    }
}
