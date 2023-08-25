using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kamienlicznik : MonoBehaviour
{
    public int stoneCount = 0;
    public Text stoneCountText; // Przeci¹gnij komponent Text z UI, który bêdzie wyœwietla³ liczbê kamieni

    private void Start()
    {
        UpdateStoneCountText();
    }

    private void UpdateStoneCountText()
    {
        stoneCountText.text = stoneCount.ToString();
    }

    public void AddStone(int dodawanie)
    {
        stoneCount = stoneCount + dodawanie;
        UpdateStoneCountText();
    }

    public void RemoveStone(int ilosc)
    {
        if (stoneCount > ilosc)
        {
            stoneCount = stoneCount - ilosc;
            UpdateStoneCountText();
        }
    }
}
