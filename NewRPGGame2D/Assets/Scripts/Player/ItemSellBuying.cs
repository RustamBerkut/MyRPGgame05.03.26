using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSellBuying : MonoBehaviour, IDropHandler
{
    public int moneyForSell;
    public static Action<int> OnItemSellAction;

    public void OnDrop(PointerEventData eventData)
    {
        var otherSlotTransform = eventData.pointerDrag.transform;
        moneyForSell = otherSlotTransform.GetComponent<UIItem>().ammoCost;
        moneyForSell /= (int)4;
        OnItemSellAction?.Invoke(moneyForSell);
        Destroy(otherSlotTransform.gameObject);
    }
}
