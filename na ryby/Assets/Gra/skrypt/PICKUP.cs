using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PICKUP : MonoBehaviour
{
    public ruszanie skrypt1;
    public KIFOLskrypt skrypt2;
    public MOLTEKskrypt skrypt3;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") != null)
        {
            skrypt1.aretoolsunlocked = true;
            skrypt2.gameObject.SetActive(true);
            skrypt3.gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
