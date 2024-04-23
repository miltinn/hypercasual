using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ebac.Core.Singleton;

public class ItemManager : Singleton<ItemManager>
{
    public SOInt coins;
    public SOInt LP;

    public TextMeshProUGUI uiTextCoins;
    public TextMeshProUGUI uiTextLP;

    private string _keyCollectable = "keyCoins";
    private string _keyLP = "keyLP";
    
    private void Start()
    {
        coins.value = 0;
        LP.value = 0;
        PlayerPrefs.SetInt(_keyCollectable, coins.value);
        PlayerPrefs.SetInt(_keyLP, LP.value);
        Reset();
    }

    private void Reset()
    {
        coins.value = 0;
        LP.value = 0;
        PlayerPrefs.SetInt(_keyCollectable, coins.value);
        PlayerPrefs.SetInt(_keyLP, LP.value);
        UpdateText();
    }

    private void UpdateText()
    {
        UIInGameManager.UpdateTextCoins($"x {PlayerPrefs.GetInt(_keyCollectable, 0)}"); //changes tmpro text "Coins" value to actual value using a Singleton
        UIInGameManager.UpdateTextLP($"x {PlayerPrefs.GetInt(_keyLP, 0)}"); //changes tmpro text "LP" value to actual value using a Singleton
    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
        PlayerPrefs.SetInt(_keyCollectable, coins.value);
        UpdateText();
    }

    public void AddLP(int amount = 1)
    {
        LP.value += amount;
        PlayerPrefs.SetInt(_keyLP, LP.value);
        UpdateText();
    }
}
