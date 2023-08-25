using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamien : MonoBehaviour
{
    private int Hits;
    private float currScale = 1f;

    private Vector3 originalPosition;
    private Vector3 originalScale;
    public float shakeDuration = 0.2f;
    public float shakeIntensity = 0.1f;
    public float scaleMultiplier = 0.2f;

    private void Start()
    {
        Hits = Random.Range(5, 10);
        currScale = scaleMultiplier * Hits;
        originalPosition = transform.position;
        originalScale = transform.localScale;
        transform.localScale = originalScale * currScale;
    }

    public void StartShake()
    {
        StartCoroutine(ShakeAndScaleCoroutine());
    }

    public System.Collections.IEnumerator ShakeAndScaleCoroutine()
    {
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            Vector3 randomOffset = Random.insideUnitSphere * shakeIntensity;
            transform.position = originalPosition + randomOffset;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if(Hits == 1)
        {
            Destroy(gameObject);
        }
        else
        {
            Hits = Hits - 1;
        }

        transform.position = originalPosition;
        currScale = scaleMultiplier * Hits;
        transform.localScale = originalScale * currScale;
        
    }
}
