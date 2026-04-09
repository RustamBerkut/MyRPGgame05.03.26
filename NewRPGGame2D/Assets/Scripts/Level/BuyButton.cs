using System;
using TMPro;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    public static Action<int> MoneyForBuyingAction;
    public GameObject noMoneycanvas;

    private readonly string moneyName = "PlayerMoneyName";
    private int moneyPlayer;
    private LootingItem LootingItem;

    private int ammoCost;

    public void OnGetPlayerMoney(int cost, LootingItem looting)
    {
        ammoCost = cost;
        LootingItem = looting;
    }
    public void OnBuyAmmo()
    {
        if (LootingItem == null) return;
        moneyPlayer = PlayerPrefs.GetInt(moneyName);
        if (ammoCost <= moneyPlayer)
        {
            MoneyForBuyingAction?.Invoke(ammoCost * -1);
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;
            Instantiate(LootingItem, player.position, player.rotation);
        }
        else
        {
            Instantiate(noMoneycanvas);
        }
    }
}
