using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Level Settings")]
    public LevelDataAsset[] levelAssets;        // assign via Inspector
    public GameObject[] blockPrefabs;           // assign your Block prefabs (Blue, Red, Yellow)
    public Transform blocksParent;              // parent object for all blocks

    [Header("Block Layout")]
    public float blockSpacingX = 0f;            // optional spacing between blocks
    public float blockSpacingY = 0f;

    private int currentLevel = 0;

    private void Start()
    {
        LoadLevel(currentLevel);
    }

    public void LoadLevel(int levelIndex)
    {
        // Cleanup old blocks
        foreach (Transform child in blocksParent)
            Destroy(child.gameObject);

        LevelDataAsset levelData = levelAssets[levelIndex];

        // Determine block size from first prefab
        float blockWidth = blockPrefabs[0].GetComponent<SpriteRenderer>().bounds.size.x + blockSpacingX;
        float blockHeight = blockPrefabs[0].GetComponent<SpriteRenderer>().bounds.size.y + blockSpacingY;

        int rows = levelData.rows.Length;
        int cols = levelData.rows[0].row.Length;

        // Center the grid relative to blocksParent
        float totalWidth = cols * blockWidth;
        float totalHeight = rows * blockHeight;
        Vector3 origin = new Vector3(-totalWidth / 2f + blockWidth / 2f, totalHeight / 2f - blockHeight / 2f, 0);

        // Instantiate blocks
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                int type = levelData.rows[r].row[c];
                if (type == 0) continue; // empty space

                GameObject prefab = blockPrefabs[type - 1];
                Vector3 localPos = new Vector3(origin.x + c * blockWidth, origin.y - r * blockHeight, 0);
                Instantiate(prefab, blocksParent.TransformPoint(localPos), Quaternion.identity, blocksParent);
            }
        }
    }

    // Optional: Call this to load next level
    public void LoadNextLevel()
    {
        currentLevel++;
        if (currentLevel >= levelAssets.Length) currentLevel = 0; // loop back
        LoadLevel(currentLevel);
    }
}


