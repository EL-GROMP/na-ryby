using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public float moveSpeed = 5.0f; // Szybko�� poruszania postaci
    private Vector3 moveDirection;
    private bool isMoving;

    private void Update()
    {
        float horizontalInput = 0f;
        float verticalInput = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            verticalInput = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            verticalInput = -1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1f;
        }

        moveDirection = new Vector3(horizontalInput, verticalInput, 0f).normalized;

        // Sprawd�, czy gracz naciska przyciski ruchu
        if (moveDirection.magnitude > 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            // Przesu� pozycj� postaci na podstawie wektora kierunku i szybko�ci
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
    }
}