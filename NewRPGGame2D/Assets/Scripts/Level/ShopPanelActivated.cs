using NUnit;
using UnityEngine;

public class ShopPanelActivated : MonoBehaviour
{
    [SerializeField]
    private GameObject questCanvas;

    private bool _isActive;
    private GameObject buttonInv;

    private void Start()
    {
        questCanvas.SetActive(false);
        buttonInv = GameObject.FindGameObjectWithTag("PlayerInventory");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isActive = true;
            OnQuestPanelActivated(_isActive);
            buttonInv.GetComponent<InventoryButton>().activatedGO.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isActive = false;
            OnQuestPanelActivated(_isActive);
            buttonInv.GetComponent<InventoryButton>().activatedGO.SetActive(false);
        }
    }
    private void OnQuestPanelActivated(bool active)
    {
        questCanvas.SetActive(active);
    }
}
