using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 5f;
    public Vector3 spawnAreaSize = new Vector3(10f, 0f, 10f);
    public int spawnLimit = 10;

    private float timeSinceLastSpawn;
    private int spawnCount; 

    private void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval && spawnCount < spawnLimit) 
        {
            SpawnEnemy();
            timeSinceLastSpawn = 0f;
        }
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
            0,
            Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
        );

        spawnPosition += transform.position;

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        spawnCount++;
        Debug.Log("Spawning");
    }

    
}
