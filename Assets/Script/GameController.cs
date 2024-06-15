using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Reference to the enemy prefab
    public float spawnInterval = 2f; // Time interval between enemy spawns

    private float xMin, xMax; // Boundaries for enemy spawning
    private Transform player; // Reference to the player's transform

    void Start()
    {
        // Set the boundaries for enemy spawning
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xMin = -7f;
        xMax = 7f;

        // Find the player's transform
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Start spawning enemies
        InvokeRepeating("SpawnEnemy", spawnInterval, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (GameManager.instance != null && GameManager.instance.isGameOver)
        {
            return; // Do not spawn enemies if game is over
        }

        float spawnX = Random.Range(xMin, xMax);
        Vector3 spawnPosition = new Vector3(spawnX, transform.position.y, transform.position.z);

        // Instantiate the enemy
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        /*if (player != null)
        {
            Vector3 direction = player.position - enemy.transform.position;
            direction.y = 0;
            enemy.transform.rotation = Quaternion.LookRotation(direction);
        }*/

    }
}
