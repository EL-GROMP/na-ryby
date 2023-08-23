using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rybiaatakacja : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Szybkoœæ poruszania siê prefabu
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(smierc());
    }

    private void Update()
    {
        if (player != null)
        {
            Vector3 moveDirection = (player.position - transform.position).normalized;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
    }
    private System.Collections.IEnumerator smierc()
    {
        yield return new WaitForSeconds(10.1f);
        Destroy(gameObject);
    }
}
