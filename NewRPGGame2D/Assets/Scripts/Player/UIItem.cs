using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public int numberOfItem;
    public Resours resours;
    public static Action UpdateItemSlotAction;

    private CanvasGroup m_CanvasGroup;
    private RectTransform rectTransform;
    private Canvas mainCanvas;

    

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        m_CanvasGroup = GetComponent<CanvasGroup>();
        mainCanvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        var _slotTransform = rectTransform.parent;
        m_CanvasGroup.blocksRaycasts = false;
        _slotTransform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / mainCanvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
        m_CanvasGroup.blocksRaycasts = true;
        UpdateItemSlotAction?.Invoke();
    }
}
public enum Resours
{
    Sword,
    Bow,
    Dual,
    Mage,
    Helmet,
    Shield,
    Body,
    Hand,
    Legs,
    HPpotion,
    MPpotion
}
