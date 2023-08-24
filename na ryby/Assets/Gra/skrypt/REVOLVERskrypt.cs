using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class REVOLVERskrypt : MonoBehaviour
{
    public Color color1 = new Color(128f / 255f, 128f / 255f, 128f / 255f);
    public Color color2 = new Color(1f, 1f, 1f);
    public GameObject rewolwero;

    public void klikniete3()
    {
        GetComponent<Image>().color = color2;
        rewolwero.SetActive(true);
    }
    public void odklikniete3()
    {
        GetComponent<Image>().color = color1;
        rewolwero.SetActive(false);
    }
}
