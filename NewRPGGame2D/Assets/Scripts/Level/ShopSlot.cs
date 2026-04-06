using System;
using UnityEngine;

public class ShopSlot : MonoBehaviour
{
    private int ammoCost;
    public static Action<int> MoneyForBuyingAction;

    private readonly string moneyName = "PlayerMoneyName";
    private int moneyPlayer;

    private void Start()
    {
        OnGetPlayerMoney();
    }
    private void OnEnable()
    {

    }
    private void OnDisable()
    {

    }
    private void OnGetPlayerMoney()
    {
        moneyPlayer = PlayerPrefs.GetInt(moneyName);
    }
    public void OnBuyAmmo()
    {
        OnGetPlayerMoney();
        OnSetupAmmoSlotInInventory();

        if (ammoCost <= moneyPlayer)
        {
            
            MoneyForBuyingAction?.Invoke(ammoCost * -1);
        }
    }

    private void OnSetupAmmoSlotInInventory()
    {
        var slot = GetComponentInChildren<UIItem>();
        ammoCost = slot.ammoCost;
    }
}
