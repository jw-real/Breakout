using UnityEngine;

public class GameManager : MonoBehaviour
{
    public LevelManager levelManager;
    public LevelData[] levels;

    private int currentLevel = 0;

    void Start()
    {
        LoadCurrentLevel();
    }

    public void LoadCurrentLevel()
    {
        levelManager.LoadLevel(levels[currentLevel]);
    }

    public void OnLevelCleared()
    {
        currentLevel++;

        if (currentLevel < levels.Length)
        {
            levelManager.ClearLevel();
            LoadCurrentLevel();
        }
        else
        {
            Debug.Log("Game completed!");
            // TODO: trigger win screen or restart
        }
    }
}
