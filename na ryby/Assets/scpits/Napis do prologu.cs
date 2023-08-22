using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Napisdoprologu : MonoBehaviour
{
    public Text textComponent;
    public string fullText = "Kacper oszala³";
    public float typingSpeed = 0.05f;

    private void Start()
    {
        StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        foreach (char character in fullText)
        {
            textComponent.text += character;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
