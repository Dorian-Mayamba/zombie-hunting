using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TextMeshProUGUI playerScoreText,playerNameText;
    void Start()
    {
        playerNameText.text = PlayerController.GetInstance().GetPlayer().PlayerName;
        playerScoreText.text = PlayerController.GetInstance().GetPlayer().PlayerScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnToMenu()
    {
        Destroy(PlayerController.GetInstance().playerInstance);
        Destroy(PlayerController.GetInstance().gameObject);
        SceneManager.LoadScene("MenuScene");
    }

    public void RestartGame()
    {
        Destroy(PlayerController.GetInstance().playerInstance);
        PlayerController.GetInstance().ResetPlayerScore();
        SceneManager.LoadScene("GameScene");
    }


}
