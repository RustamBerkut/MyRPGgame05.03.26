using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour, IDropHandler
{
    public List<Resours> resours;
    public List<GameObject> equipmentSlotOnPlayer;

    public string equipmentSlotName;
    public GameObject skillButton;

    private void Start()
    {
        OnLoadItemInSlot();
    }
    private void OnEnable()
    {
        UIItem.UpdateItemStatAction += OnUpdateSlot;
    }
    private void OnDisable()
    {
        UIItem.UpdateItemStatAction -= OnUpdateSlot;
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
            Resours res = otherSlotTransform.GetComponent<UIItem>().resours;
            int number = otherSlotTransform.GetComponent<UIItem>().numberOfItem;
            foreach (var item in resours)
            {
                if (item == res)
                {
                    otherSlotTransform.SetParent(transform);
                    otherSlotTransform.localPosition = Vector3.zero;
                    otherSlotTransform.localScale = Vector3.one;
                    skillButton.GetComponent<Image>().sprite = otherSlotTransform.GetComponent<Image>().sprite;
                    skillButton.GetComponent<SkillButton>().skillGO = otherSlotTransform.gameObject;
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
            skillButton.GetComponent<Image>().sprite = null;
            skillButton.GetComponent<SkillButton>().skillGO = null;
            OnClearItemSlot();
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
        it.transform.localScale = Vector3.one;
        int number = it.GetComponent<UIItem>().numberOfItem;
        skillButton.GetComponent<Image>().sprite = it.GetComponent<Image>().sprite;
        skillButton.GetComponent<SkillButton>().skillGO = it.gameObject;
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
