using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MOLTEKskrypt : MonoBehaviour
{
    public Color color1 = new Color(128f / 255f, 128f / 255f, 128f / 255f);
    public Color color2 = new Color(1f, 1f, 1f);

    public void klikniete2()
    {
        GetComponent<Image>().color = color2;
    }
    public void odklikniete2()
    {
        GetComponent<Image>().color = color1;
    }
}
