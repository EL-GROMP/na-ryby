using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class znikamjakpieniadzeadiego : MonoBehaviour
{
    private Renderer objectRenderer;
    private float fadeDuration = 5.0f; // Czas trwania zanikania w sekundach
    private float fadeStartTime;

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        fadeStartTime = Time.time;

        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        while (Time.time - fadeStartTime < fadeDuration)
        {
            float normalizedTime = (Time.time - fadeStartTime) / fadeDuration;
            Color objectColor = objectRenderer.material.color;
            objectColor.a = Mathf.Lerp(1f, 0f, normalizedTime);
            objectRenderer.material.color = objectColor;

            yield return null;
        }

        Destroy(gameObject);
    }
}   
