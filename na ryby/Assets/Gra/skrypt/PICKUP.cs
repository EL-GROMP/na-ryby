using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PICKUP : MonoBehaviour
{
    public ruszanie skrypt1;
    public KIFOLskrypt skrypt2;
    public MOLTEKskrypt skrypt3;
    public ScoreAndWaveManager Wave;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            skrypt1.aretoolsunlocked = true;
            skrypt2.gameObject.SetActive(true);
            skrypt3.gameObject.SetActive(true);
            Wave.StartCounting();
            Destroy(gameObject);
        }
    }
}
