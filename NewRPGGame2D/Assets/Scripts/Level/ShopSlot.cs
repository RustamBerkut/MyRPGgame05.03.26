using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    [SerializeField]
    private UIItem iItem;
    [SerializeField]
    private Image image;
    public BuyButton buyButton;

    public static Action<int> MoneyForBuyingAction;

    private int ammoCost;
    private readonly string moneyName = "PlayerMoneyName";
    private int moneyPlayer;
    private string itemDescription;
    public TextMeshProUGUI descrMeshProUGUI;

    private void Start()
    {
        image.sprite = iItem.GetComponent<Image>().sprite;
        itemDescription = iItem.itemDescription;
        ammoCost = iItem.ammoCost;
    }

    private void OnGetPlayerMoney()
    {
        moneyPlayer = PlayerPrefs.GetInt(moneyName);
    }
    public void OnSetupItemInDescription()
    {
        descrMeshProUGUI.text = string.Format("{0} Стоимость: {1}", itemDescription, ammoCost);
    }
    public void OnBuyAmmo()
    {
        OnGetPlayerMoney();
        if (ammoCost <= moneyPlayer)
        {
            MoneyForBuyingAction?.Invoke(ammoCost * -1);
        }
    }
}
