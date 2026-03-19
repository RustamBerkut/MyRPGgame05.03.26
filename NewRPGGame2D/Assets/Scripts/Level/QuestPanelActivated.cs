using UnityEngine;

public class QuestPanelActivated : MonoBehaviour
{
    [SerializeField]
    private GameObject questCanvas;

    private bool _isActive;

    private void Start()
    {
        questCanvas.SetActive(false);
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
        questCanvas.SetActive(active);
    }
}
