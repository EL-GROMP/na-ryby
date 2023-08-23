using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Napisdoprologu : MonoBehaviour
{
    public Text textComponent;
    public string fullText = "Kacper oszala³";
    public float typingSpeed = 0.05f;
    public float displayDuration = 2.0f; // Czas wyœwietlania tekstu

    private void Start()
    {
        StartCoroutine(TypeAndFade());
    }

    private IEnumerator TypeAndFade()
    {
        // Wyœwietlanie tekstu
        foreach (char character in fullText)
        {
            textComponent.text += character;
            yield return new WaitForSeconds(typingSpeed);
        }

        // Czekanie przez okreœlon¹ iloœæ czasu
        yield return new WaitForSeconds(displayDuration);

        // Zanikanie tekstu
        float fadeDuration = 1.0f; // Czas trwania zanikania tekstu
        float startAlpha = textComponent.color.a;
        float t = 0;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            Color newColor = textComponent.color;
            newColor.a = Mathf.Lerp(startAlpha, 0, t / fadeDuration);
            textComponent.color = newColor;
            yield return null;
        }

        // Usuniêcie tekstu
        textComponent.text = "";
    }
}
