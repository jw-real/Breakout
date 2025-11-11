using UnityEngine;

[CreateAssetMenu(fileName = "NewLevelData", menuName = "Breakout/Level Data")]
public class LevelData : ScriptableObject
{
    [TextArea]
    public string[] layout;
}
