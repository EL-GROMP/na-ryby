using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LASERTurret : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public string enemyTag = "Enemy";
    public float rotationSpeed = 5.0f;
    public float shootingCooldown = 2.0f;
    public float bulletSpeed = 10.0f;
    public float bulletLifetime = 3.0f;

    public AudioClip shotsound;

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
            AudioSource.PlayClipAtPoint(shotsound, transform.position);
        }
        else
        {
            // Odliczanie cooldownu strzelania
            currentShootingCooldown -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        // Tworzenie pocisku
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Nadawanie pociskowi prÍdkoúci
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = bullet.transform.right * bulletSpeed;

        // Zniszczenie pocisku po czasie øycia
        Destroy(bullet, bulletLifetime);

        // Resetowanie cooldownu strzelania
        currentShootingCooldown = shootingCooldown;
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
