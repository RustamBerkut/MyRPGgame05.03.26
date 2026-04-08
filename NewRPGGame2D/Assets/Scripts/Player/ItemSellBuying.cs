using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSellBuying : MonoBehaviour, IDropHandler
{
    
    public static Action<int> OnItemSellAction;
    public GameObject sellGO;

    private int moneyForSell;

    public void OnDrop(PointerEventData eventData)
    {
        var otherSlotTransform = eventData.pointerDrag.transform;
        moneyForSell = otherSlotTransform.GetComponent<UIItem>().ammoCost;
        moneyForSell /= (int)4;
        OnItemSellAction?.Invoke(moneyForSell);
        GameObject selGO = Instantiate(sellGO);
        selGO.GetComponentInChildren<TextMeshProUGUI>().text = string.Format("Продано за {0}", moneyForSell);
        Destroy(otherSlotTransform.gameObject);
    }
}
