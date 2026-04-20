using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int missCount = 0;
    public int maxMisses = 7;
    public bool gameEnded = false;
    public int score = 0;
    public int pointsPerMatch = 2;
    public int winScore = 20;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI missText;     

    void Awake()
    {
        Instance = this;
        Debug.Log("GameManager Initialized");
    }

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddMatchScore(int groupSize)
    {
        if (gameEnded) return;

        score += pointsPerMatch;

        UpdateScoreUI();

        if (score >= winScore && !gameEnded)
        {
            gameEnded = true;
            resultText.text = "STAGE CLEARED";
            Debug.Log("Floor Cleared!");
            Time.timeScale = 0f; // Pause the game
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public void CircleMissed()
    {
        if (gameEnded) return;

        missCount++;

        if (missCount >= maxMisses && !gameEnded)
        {
            gameEnded = true;
            resultText.text = "FLOOR FAILED";
            Debug.Log("Floor Failed!");
            Time.timeScale = 0f; // Pause the game


        }
    }


    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting..."); // This lets us see it working in the editor
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // Make sure the game is unpaused when we leave!
        SceneManager.LoadScene("Main Menu");
    }

    public void TogglePause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0f; // Freeze the game
            Debug.Log("Game Paused");
        }
        else
        {
            Time.timeScale = 1f; // Unfreeze the game
            Debug.Log("Game Resumed");
        }
    }

}