using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public Transform[] spawnPoints; 
    public float initialSpawnInterval = 4f;
    public float spawnIntervalDecreaseAmount = 0.5f;
    public float spawnIntervalDecreaseDuration = 30f;
    public float minSpawnInterval = 0.5f;

    public int initialEnemyHealth = 60;
    public int healthIncreaseAmount = 20;
    public float healthIncreaseInterval = 30f;
    public int maxEnemyHealth = 140;

    private float currentSpawnInterval;
    private float spawnTimer = 0f;
    private float healthTimer = 0f;
    private int healthIncreaseCount = 0;

    private void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
        InvokeRepeating(nameof(SpawnEnemy), 1f, currentSpawnInterval);
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        healthTimer += Time.deltaTime;

        if (spawnTimer >= spawnIntervalDecreaseDuration)
        {
            spawnTimer = 0f;
            currentSpawnInterval = Mathf.Max(currentSpawnInterval - spawnIntervalDecreaseAmount, minSpawnInterval);
            CancelInvoke(nameof(SpawnEnemy));
            InvokeRepeating(nameof(SpawnEnemy), 1f, currentSpawnInterval);
        }

        if (healthTimer >= healthIncreaseInterval)
        {
            healthTimer = 0f;
            if ((initialEnemyHealth + (healthIncreaseCount + 1) * healthIncreaseAmount) <= maxEnemyHealth)
            {
                healthIncreaseCount++;
            }
        }
    }

    private void SpawnEnemy()
    {
        if (spawnPoints.Length == 0) return;

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

        EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            int newHealth = Mathf.Min(initialEnemyHealth + (healthIncreaseCount * healthIncreaseAmount), maxEnemyHealth);
            enemyHealth.SetHealth(newHealth);
            Debug.Log("Spawned enemy with health: " + newHealth);
        }
    }
}