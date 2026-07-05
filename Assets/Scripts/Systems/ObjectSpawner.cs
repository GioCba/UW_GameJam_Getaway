using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Difficulty Configs")]
    [SerializeField]
    private DifficultyConfig easyConfig;
    [SerializeField]
    private DifficultyConfig mediumConfig;
    [SerializeField]
    private DifficultyConfig hardConfig;


    private DifficultyConfig activeConfig;

    [Header("Spawn settings")]
    [SerializeField]
    private Vector3[] spawnPoints;

    private float currentTime;

    private int totalWeight;

    private EnvironmentDifficulty currentPhase;

    private int currentEnvIndex;

    void Awake()
    {
        string savedDifficulty = PlayerPrefs.GetString("SelectedDifficulty", "Medium");

        switch (savedDifficulty)
        {
            case "Easy":
                activeConfig = easyConfig;
                break;
            case "Medium":
                activeConfig = mediumConfig;
                break;
            case "Hard":
                activeConfig = hardConfig;
                break;
        }
        
        currentPhase = activeConfig.environmentPhases[currentEnvIndex];

        for (int i = 0; i < currentPhase.weights.Length; i++)
        {
            totalWeight += currentPhase.weights[i];
        }
    }

    void Update()
    {
        if (GameManager.Instance.isGameOver || GameManager.Instance.isLevelCompleted) return;

        currentTime += Time.deltaTime;

        if (currentTime >= currentPhase.timeBetweenSpawns)
        {
            Spawn();
            currentTime -= currentPhase.timeBetweenSpawns;
        }
    }

    public void NextEnvironment()
    {
        if (currentEnvIndex + 1 < activeConfig.environmentPhases.Length)
        {
            currentEnvIndex++;
            UpdateCurrentPhaseData();
        }
    }

    private void UpdateCurrentPhaseData()
    {
        currentPhase = activeConfig.environmentPhases[currentEnvIndex];

        totalWeight = 0;

        for (int i = 0; i < currentPhase.weights.Length; i++)
        {
            totalWeight += currentPhase.weights[i];
        }
    }

    void Spawn()
    {
        int n = Random.Range(0, totalWeight);

        int cumulative = 0;

        for (int i = 0; i < currentPhase.objects.Length; i++)
        {
            cumulative += currentPhase.weights[i];

            if (n < cumulative)
            {
                Instantiate(currentPhase.objects[i], spawnPoints[Random.Range(0, spawnPoints.Length)], Quaternion.identity);
                return;
            }
        }
    }
}
