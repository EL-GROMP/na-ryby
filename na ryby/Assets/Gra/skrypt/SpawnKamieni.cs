using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKamieni : MonoBehaviour
{
    public GameObject prefabToSpawn; // Prefab do spawnowania
    public Collider2D hexagonCollider; // Obszar hexagonu
    private int maxPrefabs = 8; // Maksymalna ilo�� prefab�w
    private int currentPrefabs = 0; // Obecna ilo�� prefab�w

    private void Start()
    {
        for (int i = 0; i < maxPrefabs; i++)
        {
            SpawnPrefab();
        }
    }

    private void SpawnPrefab()
    {
        if (currentPrefabs >= maxPrefabs)
        {
            Debug.LogWarning("Osi�gni�to maksymaln� liczb� prefab�w.");
            return;
        }

        Vector2 randomPosition = GenerateRandomPositionInHexagonArea();

        Instantiate(prefabToSpawn, randomPosition, Quaternion.identity);

        currentPrefabs++;
    }

    private Vector2 GenerateRandomPositionInHexagonArea()
    {
        // Tutaj generuj losow� pozycj� wewn�trz obszaru collidera hexagonu (trigger)
        Bounds bounds = hexagonCollider.bounds;
        Vector2 randomPosition = new Vector2(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y)
        );

        return randomPosition;
    }

    public void OnPrefabDisappear()
    {
        currentPrefabs--;

        SpawnPrefab();
    }
}
