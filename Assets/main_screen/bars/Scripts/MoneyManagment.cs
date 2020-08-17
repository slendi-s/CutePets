using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManagment : MonoBehaviour
{
    public TextMeshProUGUI coins;
    public TextMeshProUGUI diamonds;

    private int coinsCount;
    private int diamondsCount;

    public static bool givemoneyforgame = false;

    private void Start()
    {
        LoadMoney();
    }

    private void Update()
    {
        if (givemoneyforgame)
        {
            coinsCount += Random.Range(1,5);
            coins.text = string.Format("{0}", coinsCount);
            givemoneyforgame = !givemoneyforgame;
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            coinsCount += 5;
            coins.text = string.Format("{0}", coinsCount);
            diamondsCount += 5;
            diamonds.text = string.Format("{0}", diamondsCount);
        }
    }

    private void OnApplicationQuit()
    {
        SaveMoney();
    }

    public void SaveMoney()
    {
        PlayerPrefs.SetInt("CoinsCount", coinsCount);
        PlayerPrefs.SetInt("DiamondsCount", diamondsCount);
    }
    public void LoadMoney()
    {
        if (PlayerPrefs.HasKey("CoinsCount"))
        {
            coins.text = string.Format("{0}", PlayerPrefs.GetInt("CoinsCount"));
            coinsCount = PlayerPrefs.GetInt("CoinsCount");
        }
        if (PlayerPrefs.HasKey("DiamondsCount"))
        {
            diamonds.text = string.Format("{0}", PlayerPrefs.GetInt("DiamondsCount"));
            diamondsCount = PlayerPrefs.GetInt("DiamondsCount");
        }
    }

}
