using NUnit;
using UnityEngine;

public class ShopPanelActivated : MonoBehaviour
{
    [SerializeField]
    private GameObject shopCanvas;

    private bool _isActive;
    private GameObject buttonInv;

    private void Start()
    {
        shopCanvas.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isActive = true;
            OnQuestPanelActivated(_isActive);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isActive = false;
            OnQuestPanelActivated(_isActive);
        }
    }
    private void OnQuestPanelActivated(bool active)
    {
        shopCanvas.SetActive(active);
    }
}
