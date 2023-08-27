using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelterRotion : MonoBehaviour
{
    public Sprite[] imageSprites; // Tablica z obrazkami
    private SpriteRenderer spriteRenderer; // Komponent SpriteRenderer
    private int currentSpriteIndex = 0; // Aktualny indeks obrazka

    public float imageSwitchInterval = 0.2f; // Interwa³ zmiany obrazka
    private float nextSwitchTime; // Czas nastêpnej zmiany obrazka

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
        currentSpriteIndex = (currentSpriteIndex + 1) % imageSprites.Length;
        spriteRenderer.sprite = imageSprites[currentSpriteIndex];
    }
}
