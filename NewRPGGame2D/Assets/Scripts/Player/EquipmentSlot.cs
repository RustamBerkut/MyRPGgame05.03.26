using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentSlot : MonoBehaviour, IDropHandler
{
    public List<Resours> resours;
    public List<GameObject> equipmentSlotOnPlayer;

    private void OnEnable()
    {
        UIItem.UpdateItemSlotAction += OnUpdateSlot;
    }
    private void OnDisable()
    {
        UIItem.UpdateItemSlotAction -= OnUpdateSlot;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            var otherSlotTransform = eventData.pointerDrag.transform;
            Resours res = otherSlotTransform.GetComponent<UIItem>().resours;
            int number = otherSlotTransform.GetComponent<UIItem>().numberOfItem;
            foreach (var item in resours)
            {
                if (item == res)
                {
                    otherSlotTransform.SetParent(transform);
                    otherSlotTransform.localPosition = Vector3.zero;
                    foreach (var slot in equipmentSlotOnPlayer)
                    {
                        slot.GetComponent<EquipmentList>().SetupItemInSlot(number);
                    }
                }
                else Debug.Log("net + {0}");
            }
        }
        else
        {
            Debug.Log("zanyto");
        }
    }
    private void OnUpdateSlot()
    {
        if (transform.childCount == 0)
        {
            foreach (var slot in equipmentSlotOnPlayer)
            {
                slot.GetComponent<EquipmentList>().SetupItemInSlot(0);
            }
        }
    }
}
