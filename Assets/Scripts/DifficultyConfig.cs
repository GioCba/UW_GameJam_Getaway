using UnityEngine;

[System.Serializable]
public struct EnvironmentDifficulty
{
    
    public string envName;
    public float timeBetweenSpawns;
    public GameObject[] objects;
    public int[] weights;
    public float maxFallSpeed;
}


[CreateAssetMenu(fileName = "DifficultyConfig", menuName = "Scriptable Objects/DifficultyConfig")]
public class DifficultyConfig : ScriptableObject
{
    public EnvironmentDifficulty[] environmentPhases;
}
