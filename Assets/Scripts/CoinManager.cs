using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public int coins = 100;
    public TextMeshProUGUI coinText;

    public TextMeshProUGUI[] itemPriceTexts;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateCoinUI();
        UpdateItemPricecolors();
    }

    public void Addcoins(int amount)
    {
        coins += amount;
        UpdateCoinUI();
        UpdateItemPricecolors();
    }

    public void SpendCoins (int amount)
    {
        if (coins >= amount)
        {
            coins -= amount;
            UpdateCoinUI();
            UpdateItemPricecolors();
        }
    }

    void UpdateCoinUI()
    {
        coinText.text = "X" + coins;
    }

    void UpdateItemPricecolors()
    {
        foreach (TextMeshProUGUI priceText in itemPriceTexts)
        {
            int itemPrice = int.Parse(priceText.text);
            if (coins >= itemPrice)
            {
                priceText.color = Color.white;
            }
            else
            {
                priceText.color = Color.red;
            }
        }
    }
}
