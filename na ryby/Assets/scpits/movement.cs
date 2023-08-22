using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public float moveSpeed = 5.0f;
    private Vector3 moveDirection;
    private bool isMoving;
    private bool cutscene = false;

    private void Update()
    {
        touchtouch();
        movementup();
    }

    private void FixedUpdate()
    {
        if (!cutscene)
        {
            if (isMoving)
            {
                // Przesun postac
                transform.position += moveDirection * moveSpeed * Time.deltaTime;
            }
        }
    }

    // VOIDY
    
    private void movementup()
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

        // Sprawdzanie klawiszy
        if (moveDirection.magnitude > 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }
    private void touchtouch()
    {
        // Sprawdzanie obiektu z tagiem
        Collider2D touchableObject = CheckForTouchableObject();
        if (touchableObject != null)
        {
            // Co sie dzieje gdy go dotknie
            cutscene1();
            touchableObject.GetComponent<rybispawner>().SpawnPrefab();
        }
    }
    private Collider2D CheckForTouchableObject()
    {
        // Obiekty dotykaj¹ce
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1.0f);

        // Czy dotykaj¹ce to tag
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Touchable"))
            {
                return collider;
            }
        }
        return null;
    }
    private void cutscene1()
    {
        cutscene = true;
    }
}
