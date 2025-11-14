using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Level Management")]
    public LevelManager levelManager;
    public Ball ballPrefab;
    public int startingLives = 3;

    private Ball currentBall;
    private int lives;

    [Header("References")]
    public GameObject ball;         // assign Ball prefab or scene object
    public GameObject paddle;       // assign Paddle scene object
    public TextMeshProUGUI scoreCounter;   // assign score
    public TextMeshProUGUI livesCounter;   // assign lives

    private void Start()
    {
        // Ensure ball and paddle are active
        if (ball != null) ball.SetActive(true);
        if (paddle != null) paddle.SetActive(true);

        // Load first level
        if (levelManager != null)
            levelManager.LoadLevel(0);
    }

    // Example method to move to next level
    public void AdvanceLevel()
    {
        if (levelManager != null)
            levelManager.LoadNextLevel();

        // Optionally reset ball and paddle here
    }
    public void LoseLife()
    {
        lives--;
        Debug.Log("Life lost. Lives remaining: " + lives);

        if (lives <= 0)
        {
            GameOver();
        }
        else
        {
            ResetBall();
        }
    }
    private void ResetBall()
    {
        if (currentBall != null)
            Destroy(currentBall.gameObject);

        currentBall = Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
    }

    private void GameOver()
    {
        Debug.Log("GAME OVER");
        // Add UI, restart logic, etc. later
    }

    public void NextLevel()
    {
        int nextIndex = levelManager.GetCurrentLevelIndex() + 1;
        if (nextIndex < levelManager.levelAssets.Length)
        {
            LoadLevel(nextIndex);
        }
        else
        {
            Debug.Log("YOU WIN!");
        }
    }
    public void LoadLevel(int index)
    {
        levelManager.LoadLevel(index);
        ResetBall();
    }
}
