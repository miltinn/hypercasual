using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ebac.Core.Singleton;

public class UIInGameManager : Singleton<UIInGameManager>
{
    public TextMeshProUGUI uiTextCoins;
    public TextMeshProUGUI uiTextLP;

    public static void UpdateTextCoins(string s)
    {
        Instance.uiTextCoins.text = s;
    }
    public static void UpdateTextLP(string s)
    {
        Instance.uiTextLP.text = s;
    }
}
