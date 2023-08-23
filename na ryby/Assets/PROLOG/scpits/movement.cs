using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    public GameObject objectToScale;
    public Camera mainCamera;
    public float moveSpeed = 5.0f;
    private Vector3 moveDirection;
    private bool isMoving;
    private bool cutscene = false;
    public GameObject boomshakalaka;
    public GameObject dziura;
    public float scalingDuration = 2.0f; // Czas trwania skalowania
    public Vector3 targetObjectScale = new Vector3(0.001f, 0.001f, 0.001f);

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
        boomshakalaka.GetComponent<prolog1>().Activate1();
        dziura.GetComponent<prolog2>().Activate2();
        StartCoroutine(Scale());
    }
    private IEnumerator Scale()
    {
        yield return new WaitForSeconds(14f);
        // Skalowanie obiektu
        float objectStartTime = Time.time;
        Vector3 objectInitialScale = objectToScale.transform.localScale;
        Vector3 objectTargetScale = new Vector3(0f, 0f, 0f);

        // Skalowanie kamery
        float cameraStartTime = Time.time;
        float cameraInitialSize = mainCamera.orthographicSize;

        while (Time.time - objectStartTime < 2)
        {
            float objectNormalizedTime = (Time.time - objectStartTime) / 2;
            objectToScale.transform.localScale = Vector3.Lerp(objectInitialScale, objectTargetScale, objectNormalizedTime);

            float cameraNormalizedTime = (Time.time - cameraStartTime) / 2;
            mainCamera.orthographicSize = Mathf.Lerp(cameraInitialSize, 1, cameraNormalizedTime);

            yield return null;
        }

        // Ustaw dok³adnie docelowe skale po zakoñczeniu interpolacji
        objectToScale.transform.localScale = objectTargetScale;
        mainCamera.orthographicSize = 1;
        SceneManager.LoadScene("Gra");
    }

}
