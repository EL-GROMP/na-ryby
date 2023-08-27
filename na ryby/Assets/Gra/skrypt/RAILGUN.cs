using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAILGUN : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public string enemyTag = "Enemy";
    public float rotationSpeed = 5.0f;
    public float shootingCooldown = 2.0f;

    public AudioClip shotsound;
    public AudioClip beforeshot;
    private int audioplaying = 1;
    private int audioplaying2 = 1;

    private float currentShootingCooldown = 0.0f;

    private GameObject currentTarget = null;

    private void Start()
    {
        currentShootingCooldown = shootingCooldown;
    }
    private void Update()
    {
        GameObject closestEnemy = FindClosestEnemyWithTag(enemyTag);

        if (closestEnemy != null)
        {
            // Obracaj dzia≥ko w kierunku wroga
            Vector3 directionToEnemy = closestEnemy.transform.position - transform.position;
            float angle = Mathf.Atan2(directionToEnemy.y, directionToEnemy.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Uaktualnij aktualny cel
            currentTarget = closestEnemy;
        }

        // Sprawdü, czy minπ≥ cooldown strzelania i czy mamy aktualny cel
        if (currentShootingCooldown <= 0 && currentTarget != null)
        {
            // Strzelanie w kierunku wroga
            Shoot();
        }
        else
        {
            // Odliczanie cooldownu strzelania
            currentShootingCooldown -= Time.deltaTime;
            if (currentShootingCooldown <= 1 && audioplaying == 1)
            {
                audioplaying--;
                AudioSource.PlayClipAtPoint(beforeshot, transform.position);
            }
            if(currentShootingCooldown <= 0.1 && audioplaying2 == 1)
            {
                audioplaying2--;
                AudioSource.PlayClipAtPoint(shotsound, transform.position);
            }
        }

    }

    void Shoot()
    {
        // Spawn strza≥u z pozycji lufy
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Resetowanie cooldownu strzelania
        currentShootingCooldown = shootingCooldown;
        audioplaying++;
        audioplaying2++;
    }

    GameObject FindClosestEnemyWithTag(string tag)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(currentPosition, enemy.transform.position);
            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }
}
