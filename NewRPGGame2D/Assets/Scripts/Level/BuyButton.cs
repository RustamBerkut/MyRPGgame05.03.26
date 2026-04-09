using System;
using TMPro;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    public GameObject spawnAmmo;
    public static Action<int> MoneyForBuyingAction;

    private UIItem iItem;
    private int ammoCost;
    private readonly string moneyName = "PlayerMoneyName";
    private int moneyPlayer;

    private string itemCost;
    private string itemDescription;

    private void OnGetPlayerMoney()
    {
        moneyPlayer = PlayerPrefs.GetInt(moneyName);

    }
    public void OnBuyAmmo()
    {
        OnGetPlayerMoney();
        if (ammoCost <= moneyPlayer)
        {
            MoneyForBuyingAction?.Invoke(ammoCost * -1);
        }
    }
    public void OnSetupUIitem(UIItem iUItem)
    {
        iItem = iUItem;
        itemDescription = iItem.itemDescription;
        itemCost = iItem.ammoCost.ToString();
    }
}
