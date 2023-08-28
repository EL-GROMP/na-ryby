using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour
{
    public float maxHP = 100;
    public int ScorePoints = 50;

    public float DamageByLaser = 1f;
    public float DamageByMelter = 0.1f;
    public float DamageByUraniumMelter = 2f;
    public float DamageByRailgun = 15f;

    public float currentHP;
    private Dictionary<string, System.Func<IEnumerator>> damageMethods = new Dictionary<string, System.Func<IEnumerator>>();

    private Transform playerTransform;
    public float followSpeed = 5.0f; // Pr�dko�� pod��ania

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        currentHP = maxHP;
        damageMethods["laser"] = TakeDamageByLaser;
        damageMethods["melter"] = TakeDamageByMelter;
        damageMethods["uranmelter"] = TakeDamageByUraniumMelter;
        damageMethods["railgun"] = TakeDamageByRailgun;
    }
    private void Update()
    {
        if (playerTransform != null)
        {
            // Oblicz kierunek do gracza
            Vector3 direction = playerTransform.position - transform.position;
            direction.Normalize();

            // Przesu� obiekt w kierunku gracza z okre�lon� pr�dko�ci�
            transform.position += direction * followSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // Sprawd�, czy kolizja jest z odpowiednim tagiem
        if (damageMethods.ContainsKey(collision.tag))
        {
            StartCoroutine(damageMethods[collision.tag]());
        }
    }

    IEnumerator TakeDamageByLaser()
    {
        if (currentHP > 0)
        {
            currentHP -= DamageByLaser; // Przyk�adowa ilo�� obra�e�
        }
        else
        {
            Die();
        }
        yield return null;
    }
    IEnumerator TakeDamageByMelter()
    {
        if (currentHP > 0)
        {
            currentHP -= DamageByMelter; // Przyk�adowa ilo�� obra�e�
        } else
        {
            Die();
        }
        yield return null;
    }
    IEnumerator TakeDamageByUraniumMelter()
    {
        if (currentHP > 0)
        {
            currentHP -= DamageByUraniumMelter; // Przyk�adowa ilo�� obra�e�
        }
        else
        {
            Die();
        }
        yield return null;
    }
    IEnumerator TakeDamageByRailgun()
    {
        if (currentHP > 0)
        {
            currentHP -= DamageByRailgun; // Przyk�adowa ilo�� obra�e�
        } else
        {
            Die();
        }
        yield return null;
    }

    void Die()
    {
        // Wykonaj akcje zwi�zane z umieraniem wroga (np. dodaj punkty)
        // ...
        Destroy(gameObject); // Zniszcz wroga
    }
}
