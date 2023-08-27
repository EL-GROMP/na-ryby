using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class railgunBULLET : MonoBehaviour
{
    public Sprite[] imageSprites; // Tablica z obrazkami
    private SpriteRenderer spriteRenderer; // Komponent SpriteRenderer
    private int currentSpriteIndex = 0; // Aktualny indeks obrazka
    private int spritenumb = 0;

    public float imageSwitchInterval = 0.2f; // Interwa� zmiany obrazka
    private float nextSwitchTime; // Czas nast�pnej zmiany obrazka

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = imageSprites[currentSpriteIndex];
        nextSwitchTime = Time.time + imageSwitchInterval;
    }

    private void Update()
    {
        if (Time.time >= nextSwitchTime)
        {
            SwitchToNextImage();
            nextSwitchTime = Time.time + imageSwitchInterval;
        }
    }

    private void SwitchToNextImage()
    {
        if (spritenumb == 4)
        {
            Destroy(gameObject);
        }
        spritenumb++;
        currentSpriteIndex = (currentSpriteIndex + 1) % imageSprites.Length;
        spriteRenderer.sprite = imageSprites[currentSpriteIndex];
    }
}
