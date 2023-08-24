using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rewolwero : MonoBehaviour
{
    public Transform pivot;
    public float speed = 20f;
    private float zRotationOffset = 90f;
    private float distance = 5f;
    private float minAngle = 90f;
    private float maxAngle = 270f;
    public GameObject bulletPrefab;
    public AudioClip shotSound;
    public float shotCooldown = 3f;
    private float lastShotTime;

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 direction = (mousePosition - pivot.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);

        float angle = transform.eulerAngles.z;
        if (angle > minAngle && angle < maxAngle)
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        transform.position = pivot.position + (rotation * Vector3.up) * distance;
        rotation *= Quaternion.Euler(0, 0, zRotationOffset);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0) && Time.time - lastShotTime >= shotCooldown)
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {

        GameObject LASER = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Rigidbody2D rb = LASER.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * 75f;
        AudioSource.PlayClipAtPoint(shotSound, transform.position);
        lastShotTime = Time.time;
    }

    public void Upgrade1()
    {
        shotCooldown = shotCooldown * 0.55f;
    }
}
