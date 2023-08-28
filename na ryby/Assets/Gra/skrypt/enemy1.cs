using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour
{
    public float maxHP = 100;
    public int ScorePoints = 50;
    public float damageRate = 0.01f; // Przyk³adowa iloœæ obra¿eñ na sekundê

    public float DamageByLaser = 1f;
    public float DamageByMelter = 0.1f;
    public float DamageByUraniumMelter = 2f;
    public float DamageByRailgun = 15f;

    public float currentHP;
    private bool isTakingDamageL = false;
    private bool isTakingDamageM = false;
    private bool isTakingDamageUM = false;
    private bool isTakingDamageR = false;

    private void Start()
    {
        currentHP = maxHP;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // SprawdŸ, czy kolizja jest z odpowiednim tagiem
        if (collision.CompareTag("laser"))
        {
            if (!isTakingDamageL)
            {
                StartCoroutine(TakeDamageByLaser());
            }
        }
        if (collision.CompareTag("melter"))
        {
            if (!isTakingDamageM)
            {
               // StartCoroutine(TakeDamageByMelter());
            }
        }
        if (collision.CompareTag("uranmelter"))
        {
            if (!isTakingDamageUM)
            {
               // StartCoroutine(TakeDamageByUraniumMelter());
            }
        }
        if (collision.CompareTag("railgun"))
        {
            if (!isTakingDamageR)
            {
               // StartCoroutine(TakeDamageByRailgun());
            }
        }
    }

    IEnumerator TakeDamageByLaser()
    {
        isTakingDamageL = true;
        if (currentHP > 0)
        {
            currentHP -= DamageByLaser; // Przyk³adowa iloœæ obra¿eñ
        }
        else
        {
            Die();
        }
        yield return new WaitForSeconds(damageRate);
        isTakingDamageL = false;
    }
    IEnumerator TakeDamageByMelter()
    {
        isTakingDamageM = true;
        if (currentHP > 0)
        {
            currentHP -= DamageByMelter; // Przyk³adowa iloœæ obra¿eñ
        } else
        {
            Die();
        }
        yield return new WaitForSeconds(damageRate);
        isTakingDamageM = false;
    }
    IEnumerator TakeDamageByUraniumMelter()
    {
        isTakingDamageUM = true;
        if (currentHP > 0)
        {
            currentHP -= DamageByUraniumMelter; // Przyk³adowa iloœæ obra¿eñ
        }
        else
        {
            Die();
        }
        yield return new WaitForSeconds(damageRate);
        isTakingDamageUM = false;
    }
    IEnumerator TakeDamageByRailgun()
    {
        isTakingDamageR = true;
        if (currentHP > 0)
        {
            currentHP -= DamageByRailgun; // Przyk³adowa iloœæ obra¿eñ
            yield return new WaitForSeconds(damageRate);
        } else
        {
            Die();
        }
        yield return new WaitForSeconds(damageRate);
        isTakingDamageR = false;
    }

    void Die()
    {
        // Wykonaj akcje zwi¹zane z umieraniem wroga (np. dodaj punkty)
        // ...
        Destroy(gameObject); // Zniszcz wroga
    }
}
