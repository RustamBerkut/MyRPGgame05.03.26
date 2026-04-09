using NUnit.Framework;
using PlayerBehaviour;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    public static Action<int> MoneyForBuyingAction;
    public GameObject noMoneycanvas, noCapacityCanvas;

    private readonly string moneyName = "PlayerMoneyName";
    private int moneyPlayer;
    private LootingItem LootingItem;

    private int ammoCost;
    public List<InventorySlot> UIItems;

    public void OnGetPlayerMoney(int cost, LootingItem looting)
    {
        ammoCost = cost;
        LootingItem = looting;
    }
    public void OnBuyAmmo()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        UIItems = player.gameObject.GetComponent<PlayerInventory>().UIslots;
        for (int i = 0; i < UIItems.Count; i++)
        {
            if (UIItems[i].transform.childCount == 0)
            {
                if (LootingItem == null) return;
                moneyPlayer = PlayerPrefs.GetInt(moneyName);
                if (ammoCost <= moneyPlayer)
                {
                    MoneyForBuyingAction?.Invoke(ammoCost * -1);
                    Instantiate(LootingItem, player.position, player.rotation);
                }
                else
                {
                    Instantiate(noMoneycanvas);
                }
                break;
            }
            else
            {
                //Instantiate(noCapacityCanvas);
            }
        }
    }
}
