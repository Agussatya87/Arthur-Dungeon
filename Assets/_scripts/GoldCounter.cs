using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldCounter : MonoBehaviour
{
    public static GoldCounter instance;

    public TMP_Text coinText;
    public int currentCoins = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        coinText.text = "COINS: " + currentCoins.ToString();
    }

    public void IncreaseCoins(int v)
    {
        currentCoins += v;
        coinText.text = "COINS: " + currentCoins.ToString();
    }
}
