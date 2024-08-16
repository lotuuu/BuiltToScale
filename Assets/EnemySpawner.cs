using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnRate = 5f;
    [SerializeField] float spawnRateVariance = 1.5f;
    float spawnTimer = 0f;
    int minimumEnemies = 2;

    EnemiesTracker enemiesTracker;

    [SerializeField] GameObject spawnArea;

    void Start()
    {
        enemiesTracker = FindObjectOfType<EnemiesTracker>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Check if there are enough enemies
        if (enemiesTracker.EnemyCount < minimumEnemies)
        {
            spawnTimer = 0f;
        }

        // Reduce spawn rate by time
        spawnTimer -= Time.fixedDeltaTime;

        // Spawn enemy
        if (spawnTimer <= 0f)
        {
            GameObject enemy = Instantiate(enemyPrefab, GetSpawnArea(), Quaternion.identity);
            spawnTimer = spawnRate + Random.Range(-spawnRateVariance, spawnRateVariance);
        }
    }

    Vector3 GetSpawnArea()
    {
        Vector3 spawnAreaPosition = spawnArea.transform.position;
        Vector3 spawnAreaSize = spawnArea.transform.localScale;
        float x = Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2);
        float y = Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2);
        return spawnAreaPosition + new Vector3(x, y, 0);
    }
}
