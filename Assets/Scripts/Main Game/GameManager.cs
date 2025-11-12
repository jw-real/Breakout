using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Level Management")]
    public LevelManager levelManager;

    [Header("Ball & Paddle")]
    public GameObject ball;      // assign Ball prefab or scene object
    public GameObject paddle;    // assign Paddle scene object

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
}
