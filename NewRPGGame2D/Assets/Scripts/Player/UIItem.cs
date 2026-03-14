using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class UIItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public int numberOfItem;
    public Resours resours;
    public static Action UpdateItemStatAction;
    public int STR, DEX, INT, CON, meleeAttack, bowAttack,
        mageAttack, shield, MP, HP;
    public string itemName;
    public Texture2D icon;

    [TextArea]
    [SerializeField]
    private string itemDescription;

    private CanvasGroup m_CanvasGroup;
    private RectTransform rectTransform;
    private Canvas mainCanvas;

    private bool isDescr = false;
    
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        m_CanvasGroup = GetComponent<CanvasGroup>();
        mainCanvas = GetComponentInParent<Canvas>();
        UpdateItemStatAction?.Invoke();
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
        UpdateItemStatAction?.Invoke();
    }
    void OnGUI()
    {
        if (!isDescr) return;
        GUIStyle guiStyle = new(GUI.skin.box)
        {
            fontSize = 36
        };
        guiStyle.normal.background = icon;
        guiStyle.alignment = TextAnchor.MiddleCenter;
        GUI.Box(new Rect(Screen.width / 2 - 550, Screen.height / 2 - 50, 300, 330), itemDescription, guiStyle);
    }
    public void OnMouseEnterItem()
    {
        isDescr = true;
    }
    public void OnMouseExitItem() 
    { 
        isDescr = false; 
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