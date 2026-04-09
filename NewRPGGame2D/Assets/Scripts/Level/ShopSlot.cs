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

    private void Start()
    {
        image.sprite = iItem.GetComponent<Image>().sprite;
    }

    public void OnSetupAmmoSlotInDescription()
    {
        buyButton.OnSetupUIitem(iItem);
    }
}
