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
    }

    private void Update()
    {
        if (player != null)
        {
            Vector3 moveDirection = (player.position - transform.position).normalized;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
    }
}
