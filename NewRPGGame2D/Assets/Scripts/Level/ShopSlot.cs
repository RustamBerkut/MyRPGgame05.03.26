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


    private void Start()
    {
        image.sprite = iItem.GetComponent<Image>().sprite;
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
    [TextArea]
    [SerializeField]
    private string itemDescription;
    private string itemCost;
    public Texture2D icon;
    private bool isDescr = false;

    void OnGUI()
    {
        if (!isDescr) return;
        GUIStyle guiStyle = new(GUI.skin.box)
        {
            fontSize = 35
        };
        guiStyle.normal.background = icon;
        guiStyle.alignment = TextAnchor.MiddleCenter;
        GUI.Box(new Rect(Screen.width / 2, Screen.height / 2 - 450, 500, 500), itemDescription, guiStyle);
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
