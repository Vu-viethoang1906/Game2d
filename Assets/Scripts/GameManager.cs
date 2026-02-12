using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private bool isGameOver = false;
    public bool IsGameOver => isGameOver;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Update()
    {
        if (isGameOver) return;
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        if (playerHealth == null)
        {
            OnGameOver();
        }
        EnemyHealth[] enemies = FindObjectsOfType<EnemyHealth>();
        if (enemies.Length == 0)
        {
            OnGameWin();
        }
    }

    public void OnGameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        Debug.Log("Game Over - Player Died!");
        GameOverUI gameOverUI = FindObjectOfType<GameOverUI>();
        if (gameOverUI != null)
        {
            gameOverUI.ShowGameOver();
        }
        Time.timeScale = 0f;
    }

    public void OnGameWin()
    {
        if (isGameOver) return;

        isGameOver = true;
        Debug.Log("Game Win - All enemies defeated!");
        GameOverUI gameOverUI = FindObjectOfType<GameOverUI>();
        if (gameOverUI != null)
        {
            gameOverUI.ShowGameWin();
        }
        Time.timeScale = 0f;
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
