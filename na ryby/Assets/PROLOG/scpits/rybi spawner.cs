using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rybispawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public Vector2 spawnAreaSize = new Vector2(5f, 5f);
    public float loopDuration = 3.0f;
    private float elapsedTime = 0f;

    public void SpawnPrefab()
    {
        Vector3 newPosition = transform.position;
        newPosition.y = 75.0f;
        transform.position = newPosition;

        StartCoroutine(SpawnLoopCoroutine());
    }

    private System.Collections.IEnumerator SpawnLoopCoroutine()
    {
        while (elapsedTime < 150)
        {
            elapsedTime++; // Zaktualizuj up³ywaj¹cy czas

            Vector2 spawnPosition = GetRandomSpawnPosition();
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

            yield return null;
        }
    }

    private Vector2 GetRandomSpawnPosition()
    {
        Vector2 randomPoint = new Vector2(
            Random.Range(transform.position.x - spawnAreaSize.x / 2, transform.position.x + spawnAreaSize.x / 2),
            Random.Range(transform.position.y - spawnAreaSize.y / 2, transform.position.y + spawnAreaSize.y / 2)
        );

        return randomPoint;
    }
}
