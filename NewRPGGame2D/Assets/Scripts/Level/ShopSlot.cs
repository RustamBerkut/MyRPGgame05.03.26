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

    private int ammoCost;
    public static Action<int> MoneyForBuyingAction;

    private readonly string moneyName = "PlayerMoneyName";
    private int moneyPlayer;

    private string itemCost;
    public Texture2D icon;
    private bool isDescr = false;
    private string itemDescription;

    private void Start()
    {
        image.sprite = iItem.GetComponent<Image>().sprite;
        itemDescription = iItem.itemDescription;
        itemCost = iItem.ammoCost.ToString();
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


    void OnGUI()
    {
        if (!isDescr) return;
        GUIStyle guiStyle = new(GUI.skin.box)
        {
            fontSize = 35
        };
        guiStyle.normal.background = icon;
        guiStyle.alignment = TextAnchor.MiddleCenter;
        GUI.Box(new Rect(0, 0, 500, 500), itemDescription, guiStyle);
    }
    public void OnMouseEnterItem()
    {
        isDescr = true;
    }
    public void OnMouseExitItem()
    {
        isDescr = false;
    }
}
