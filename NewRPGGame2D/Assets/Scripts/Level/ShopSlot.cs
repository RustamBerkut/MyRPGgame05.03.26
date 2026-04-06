using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopSlot : MonoBehaviour
{
    [SerializeField]
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

        if (ammoCost <= moneyPlayer)
        {
            OnSetupAmmoSlotInInventory();
            MoneyForBuyingAction?.Invoke(ammoCost * -1);
        }
    }

    private void OnSetupAmmoSlotInInventory()
    {
        var slot = GetComponentInChildren<UIItem>();
    }

}
