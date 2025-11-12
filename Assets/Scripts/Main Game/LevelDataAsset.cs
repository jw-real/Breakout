using UnityEngine;

[System.Serializable]
public class IntArray
{
    [Tooltip("Each element represents a block type. 0 = empty.")]
    public int[] row;
}

[CreateAssetMenu(fileName = "NewLevelData", menuName = "Breakout/Level Data")]
public class LevelDataAsset : ScriptableObject
{
    [Tooltip("Each IntArray represents a row of the level.")]
    public IntArray[] rows;
}
