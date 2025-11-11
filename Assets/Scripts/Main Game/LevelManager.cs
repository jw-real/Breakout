using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform blocksParent;
    public GameObject[] blockPrefabs;
    public float blockWidth = 1f;
    public float blockHeight = 0.5f;

    private GameManager gameManager;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void LoadLevel(LevelData data)
    {
        for (int y = 0; y < data.layout.Length; y++)
        {
            string row = data.layout[y];
            for (int x = 0; x < row.Length; x++)
            {
                int type = row[x] - '1';
                if (type >= 0 && type < blockPrefabs.Length)
                {
                    Vector3 pos = new Vector3(x * blockWidth, -y * blockHeight, 0);
                    Instantiate(blockPrefabs[type], pos, Quaternion.identity, blocksParent);
                }
            }
        }
    }

    public void ClearLevel()
    {
        foreach (Transform child in blocksParent)
        {
            Destroy(child.gameObject);
        }
    }

    void Update()
    {
        if (blocksParent.childCount == 0)
        {
            gameManager.OnLevelCleared();
        }
    }
}

