using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject gameOverPanel; // Reference to the Game Over UI panel
    public bool isGameOver = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        gameOverPanel.SetActive(false); // Ensure Game Over panel is hidden at start
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            gameOverPanel.SetActive(true); // Show Game Over panel

            // Stop enemy spawning
            CancelInvoke("SpawnEnemy");

            // Stop other game activities here
            Time.timeScale = 0f; // Pause the game
        }
    }
}
