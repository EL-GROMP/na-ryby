using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KIFOLskrypt : MonoBehaviour
{
    public Color color1 = new Color(128f / 255f, 128f / 255f, 128f / 255f);
    public Color color2 = new Color(1f, 1f, 1f);
    public GameObject kilof;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void klikniete1()
    {
        GetComponent<Image>().color = color2;
        kilof.SetActive(true);
    }
    public void odklikniete1()
    {
        GetComponent<Image>().color = color1;
        kilof.SetActive(false);
    }
}
