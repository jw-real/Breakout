using UnityEngine;
using UnityEditor;

public class CreateLevelAssets
{
    [MenuItem("Breakout/Create Default Levels")]
    public static void CreateLevels()
    {
        // --- LEVEL 1 ---
        LevelDataAsset level1 = ScriptableObject.CreateInstance<LevelDataAsset>();
        level1.rows = new IntArray[3];

        // Row 0
        level1.rows[0] = new IntArray { row = new int[10] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 } };
        // Row 1
        level1.rows[1] = new IntArray { row = new int[10] { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 } };
        // Row 2
        level1.rows[2] = new IntArray { row = new int[10] { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 } };

        AssetDatabase.CreateAsset(level1, "Assets/Level1.asset");
        AssetDatabase.SaveAssets();

        // --- LEVEL 2 ---
        LevelDataAsset level2 = ScriptableObject.CreateInstance<LevelDataAsset>();
        level2.rows = new IntArray[3];

        // Example layout
        level2.rows[0] = new IntArray { row = new int[10] { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 } };
        level2.rows[1] = new IntArray { row = new int[10] { 2, 2, 2, 2, 0, 0, 2, 2, 2, 2 } };
        level2.rows[2] = new IntArray { row = new int[10] { 1, 1, 0, 1, 1, 1, 1, 0, 1, 1 } };

        AssetDatabase.CreateAsset(level2, "Assets/Level2.asset");
        AssetDatabase.SaveAssets();

        Debug.Log("Level1.asset and Level2.asset created in Assets folder.");
    }
}

