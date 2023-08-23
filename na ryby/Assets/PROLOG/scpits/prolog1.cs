using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prolog1 : MonoBehaviour
{
    public Transform playerTransform;
    public Sprite[] sprites; // Tablica ze sprite'ami
    public float spriteChangeSpeed = 0.1f; // Prêdkoœæ zmiany sprite'a
    private SpriteRenderer spriteRenderer;
    private int currentSpriteIndex = 0;
    public Vector3 offset;

    public void Activate1()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform.position = playerTransform.position + offset;
        StartCoroutine(ChangeSprite());
    }
    private System.Collections.IEnumerator ChangeSprite()
    {
        yield return new WaitForSeconds(10);
        while (currentSpriteIndex < sprites.Length)
        {
            spriteRenderer.sprite = sprites[currentSpriteIndex];
            currentSpriteIndex++;
            yield return new WaitForSeconds(spriteChangeSpeed);
        }
        // Po zakoñczeniu cyklu zmiany sprite'ów, usuñ obiekt
        Destroy(gameObject);
    }
}
