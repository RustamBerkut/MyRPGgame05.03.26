using UnityEngine;

public class StatDescr : MonoBehaviour
{
    [TextArea]
    [SerializeField]
    private string itemDescription;
    public Texture2D icon;
    private bool isDescr = false;

    void OnGUI()
    {
        if (!isDescr) return;
        GUIStyle guiStyle = new(GUI.skin.box)
        {
            fontSize = 35
        };
        guiStyle.normal.background = icon;
        guiStyle.alignment = TextAnchor.MiddleCenter;
        GUI.Box(new Rect(Screen.width / 2, 0, 450, 420), itemDescription, guiStyle);
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
