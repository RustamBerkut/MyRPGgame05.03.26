using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            var otherSlotTransform = eventData.pointerDrag.transform;
            otherSlotTransform.SetParent(transform);
            otherSlotTransform.localPosition = Vector3.zero;
        }
        else
        {
            Debug.Log("zanyto");
        }
    }
}
