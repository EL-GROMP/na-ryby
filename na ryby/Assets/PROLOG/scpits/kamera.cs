using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float followSpeed = 0.5f;

    void Update()
    {
        if (player == null) return;
        transform.position = Vector3.Lerp(transform.position, player.position + offset, followSpeed * Time.deltaTime);
    }
}
