using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public string equipmentSlotName;

    private void Start()
    {
        OnLoadItemInSlot();
    }

    private void OnDisable()
    {
        if (transform.childCount != 0)
        {
            string value = gameObject.GetComponentInChildren<UIItem>().itemName;
            OnSaveItemInSlot(value);
        }
        if (transform.childCount == 0)
        {
            OnClearItemSlot();
        }
    }


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

    private void OnLoadItemInSlot()
    {
        if (!PlayerPrefs.HasKey(equipmentSlotName)) return;

        string value = PlayerPrefs.GetString(equipmentSlotName);
        value = string.Format("Loot/{0}", value);
        var it = (GameObject)Instantiate(Resources.Load(value));
        it.transform.SetParent(transform);
        it.transform.localPosition = Vector3.zero;
    }
    public void OnSaveItemInSlot(string item)
    {
        PlayerPrefs.SetString(equipmentSlotName, item);
    }
    private void OnClearItemSlot()
    {
        PlayerPrefs.DeleteKey(equipmentSlotName);
    }
}
