using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;

public class EquipmentSlot : MonoBehaviour, IDropHandler
{
    public List<Resours> resours;
    public List<GameObject> equipmentSlotOnPlayer;

    public string equipmentSlotName;

    private void OnEnable()
    {
        OnLoadItemInSlot();
        UIItem.UpdateItemStatAction += OnUpdateSlot;
    }
    private void OnDisable()
    {
        UIItem.UpdateItemStatAction -= OnUpdateSlot;
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
                    OnSaveItemInSlot(otherSlotTransform.GetComponent<UIItem>().itemName);
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
                OnClearItemSlot();
            }
        }
    }
    private void OnLoadItemInSlot()
    {
        if (!PlayerPrefs.HasKey(equipmentSlotName)) return;

        string value = PlayerPrefs.GetString(equipmentSlotName);
        value = string.Format("Loot/{0}", value);
        var it = (GameObject)Instantiate(Resources.Load(value));
        it.transform.SetParent(transform);
        it.transform.localPosition = Vector3.zero;
        int number = it.GetComponent<UIItem>().numberOfItem;
        foreach (var slot in equipmentSlotOnPlayer)
        {
            slot.GetComponent<EquipmentList>().SetupItemInSlot(number);
        }
    }
    private void OnSaveItemInSlot(string item)
    {
        PlayerPrefs.SetString(equipmentSlotName, item);
    }
    private void OnClearItemSlot()
    {
        PlayerPrefs.DeleteKey(equipmentSlotName);
    }
}
