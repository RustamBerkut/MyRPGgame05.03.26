using UnityEngine;

public class ItemActivatedByButton : MonoBehaviour
{
    public GameObject activatedGO;

    private bool isActive;

    private void Start()
    {
        activatedGO.SetActive(false);
    }
    public void OnActivated()
    {
        isActive = !isActive;
        activatedGO.SetActive(isActive);
    }
}
