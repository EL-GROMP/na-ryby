using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MOLTEKskrypt : MonoBehaviour
{
    public Color color1 = new Color(128f / 255f, 128f / 255f, 128f / 255f);
    public Color color2 = new Color(1f, 1f, 1f);
    public GameObject mlotek;
    public budowanie script1;

    public void klikniete2()
    {
        script1.ShowRange();
        mlotek.SetActive(true);
        GetComponent<Image>().color = color2;
    }
    public void odklikniete2()
    {
        script1.HideRange();
        mlotek.SetActive(false);
        GetComponent<Image>().color = color1;
    }
}
