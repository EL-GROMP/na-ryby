using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform Player;
    //public ScoreManager scorescript;
    public GameObject enemyType1;
    public GameObject enemyType2;
    public GameObject enemyType3;
    public GameObject enemyType4;
    public GameObject enemyType5;

    private Vector2 spawnPoint; // punkt respawnu wroga
    private int waveNumber = 0; // numer aktualnej fali
    private int waveBudget = 10; // maksymalny bud�et
    private int enemyCost1 = 1; // cena wroga typu 1
    private int enemyCost2 = 1; // cena wroga typu 2
    private int enemyCost3 = 2; // cena wroga typu 3
    private int enemyCost4 = 3; // cena wroga typu 4
    private int enemyCost5 = 4; // cena wroga typu 5
    private int budget = 0; // bud�et fali
    public ScoreAndWaveManager SWManager; // skrypt do tekstu fali


    public void SpawnEnemies()
    {
        StartCoroutine(SpawnWave());
    }

    public IEnumerator SpawnWave()
    {
        waveNumber++;
        //waveText.text = "Wave " + waveNumber.ToString();
        budget = waveBudget + waveNumber * waveNumber;

        while (budget > 0)
        {
            int enemyToSpawn = Random.Range(1, 6); // choose a random enemy
            switch (enemyToSpawn)
            {
                case 1:
                    if (budget - enemyCost1 >= 0)
                    {
                        spawnPoint = GetRandomPointOutsideArea();
                        Instantiate(enemyType1, spawnPoint, Quaternion.identity);
                        budget -= enemyCost1;
                    }
                    break;
                case 2:
                    if (budget - enemyCost2 >= 0)
                    {
                        spawnPoint = GetRandomPointOutsideArea();
                        Instantiate(enemyType2, spawnPoint, Quaternion.identity);
                        budget -= enemyCost2;
                    }
                    break;
                case 3:
                    if (budget - enemyCost3 >= 0)
                    {
                        spawnPoint = GetRandomPointOutsideArea();
                        Instantiate(enemyType3, spawnPoint, Quaternion.identity);
                        budget -= enemyCost3;
                    }
                    break;
                case 4:
                    if (budget - enemyCost4 >= 0)
                    {
                        spawnPoint = GetRandomPointOutsideArea();
                        Instantiate(enemyType4, spawnPoint, Quaternion.identity);
                        budget -= enemyCost4;
                    }
                    break;
                case 5:
                    if (budget - enemyCost5 >= 0)
                    {
                        spawnPoint = GetRandomPointOutsideArea();
                        Instantiate(enemyType5, spawnPoint, Quaternion.identity);
                        budget -= enemyCost5;
                    }
                    break;
                default:
                    break;
            }
        }
        while (GameObject.FindWithTag("Enemy"))
        {
            yield return null;
        }
        SWManager.StartCounting();
    }

    private Vector2 GetRandomPointOutsideArea()
    {
        Vector2 playerPosition = Player.position;
        Vector2 spawnPoint;

        do
        {
            // Generuj losową odległość i kąt w radianach
            float distance = Random.Range(400f, 600f);
            float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;

            // Oblicz pozycję wroga w oparciu o odległość i kąt
            float x = playerPosition.x + distance * Mathf.Cos(angle);
            float y = playerPosition.y + distance * Mathf.Sin(angle);

            spawnPoint = new Vector2(x, y);
        } while (false);
        return spawnPoint;
    }
}
