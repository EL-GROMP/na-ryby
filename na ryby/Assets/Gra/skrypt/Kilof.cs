using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kilof : MonoBehaviour
{
    public Transform pivot;
    public float speed = 20f;
    private float zRotationOffset = 90f;
    private float distance = 3f;
    private float minAngle = 90f;
    private float maxAngle = 270f;
    public AudioClip miningSound;
    public float miningCooldown = 3f;
    private float lastMinedTime;

    public float rotationDuration = 0.5f;
    public float rotationAngle = 45.0f;
    private bool isAnimating = false;

    public ruszanie script0;
    public kamienlicznik licznikkamieni;

    void Update()
    {
        if (!isAnimating)
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

            if (Input.GetMouseButtonDown(0) && Time.time - lastMinedTime >= miningCooldown && !isAnimating)
            {
                StartCoroutine(AnimateRotation(angle));
            }
        }
    }

    private IEnumerator AnimateRotation(float startAngle)
    {
        isAnimating = true;
        script0.isAnimationON();

        lastMinedTime = Time.time;

        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0, 0, startAngle + rotationAngle);
        Quaternion secondTargetRotation = Quaternion.Euler(0, 0, startAngle - rotationAngle);
        float elapsedTime = 0.0f;

        while (elapsedTime < rotationDuration)
        {
            if (startAngle > minAngle && startAngle < maxAngle)
            {
                transform.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsedTime / rotationDuration);
            }
            else
            {
                transform.rotation = Quaternion.Lerp(startRotation, secondTargetRotation, elapsedTime / rotationDuration);
            }
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if (startAngle > minAngle && startAngle < maxAngle)
        {
            transform.rotation = targetRotation;
        }
        else
        {
            transform.rotation = secondTargetRotation;
        }

        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, GetComponent<BoxCollider2D>().size, 0);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("kamien1"))
            {
                kamien stone = collider.GetComponent<kamien>();
                if (stone != null)
                {
                    AudioSource.PlayClipAtPoint(miningSound, transform.position);
                    licznikkamieni.AddStone(1);
                    stone.StartShake();
                }
            }
        }

        yield return new WaitForSeconds(0.3f); // Odst�p mi�dzy obr�tami

        elapsedTime = 0.0f;

        while (elapsedTime < rotationDuration)
        {
            if (startAngle > minAngle && startAngle < maxAngle)
            {
                transform.rotation = Quaternion.Lerp(targetRotation, startRotation, elapsedTime / rotationDuration);
            }
            else
            {
                transform.rotation = Quaternion.Lerp(secondTargetRotation, startRotation, elapsedTime / rotationDuration);
            }
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = startRotation;
        script0.isAnimationOFF();
        isAnimating = false;
    }
}