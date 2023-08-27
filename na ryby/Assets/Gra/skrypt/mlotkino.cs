using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mlotkino : MonoBehaviour
{
    public Transform pivot;
    public float speed = 20f;
    private float zRotationOffset = 90f;
    private float distance = 5f;
    private float minAngle = 90f;
    private float maxAngle = 270f;
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 direction = (mousePosition - pivot.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);

        float angle = transform.eulerAngles.z;

        if (angle > minAngle && angle < maxAngle)
        {
            transform.localScale = new Vector3(10, -10, 10);
        }
        else
        {
            transform.localScale = new Vector3(10, 10, 10);
        }

        transform.position = pivot.position + (rotation * Vector3.up) * distance;
        rotation *= Quaternion.Euler(0, 0, zRotationOffset);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
}
