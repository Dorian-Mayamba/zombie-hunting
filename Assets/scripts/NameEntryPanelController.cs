using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using TMPro;
using UnityEngine.InputSystem;

public class NameEntryPanelController : MonoBehaviour
{

    [SerializeField] private TMP_InputField nameField;
    // Start is called before the first frame update
    PlayerController playerController;

    private string playerName = "Unnamed";
    public void NavigateToGameScene()
    {
        if(nameField.text.Length > 0){
            playerName = nameField.text;
            playerController.InitPlayer(playerName);
            
        }else{
            playerController.InitPlayer(playerName);
        }
        SceneManager.LoadSceneAsync("GameScene");
    }

    private void Start() {
        playerController = PlayerController.GetInstance();
    }
}
