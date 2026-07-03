using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Spawnable Objects")]
    [SerializeField]
    private GameObject[] objects;

    [Header("Spawn settings")]
    [SerializeField]
    private Vector3[] spawnPoints;
    [SerializeField]
    private float timeBetweenSpawns;

    private float currentTime;


    void Update()
    {
        if (GameManager.Instance.isGameOver) return;

        currentTime += Time.deltaTime;

        if (currentTime >= timeBetweenSpawns)
        {
            Spawn();
            currentTime -= timeBetweenSpawns;
        }
    }

    void Spawn()
    {
        Instantiate(objects[Random.Range(0, objects.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)], Quaternion.identity);
    }
}
