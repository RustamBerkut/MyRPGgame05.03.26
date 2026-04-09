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

    private int ammoCost;

    LootingItem lootingItem;
    private string itemDescription;
    public TextMeshProUGUI descrMeshProUGUI;

    private void Start()
    {
        image.sprite = iItem.GetComponent<Image>().sprite;
        itemDescription = iItem.itemDescription;
        ammoCost = iItem.ammoCost;
        lootingItem = iItem.LootingItem;
    }

    public void OnSetupItemInDescription()
    {
        descrMeshProUGUI.text = string.Format("{0} Стоимость: {1}", itemDescription, ammoCost);
        buyButton.OnGetPlayerMoney(ammoCost, lootingItem);
    }
}
