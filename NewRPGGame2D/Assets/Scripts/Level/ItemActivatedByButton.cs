using System.Collections;
using UnityEngine;

public class ItemActivatedByButton : MonoBehaviour
{
    public GameObject activatedGO;

    private bool isActive;

    private void Start()
    {
        StartCoroutine(nameof(IsPanelactive));
    }
    IEnumerator IsPanelactive()
    {
        yield return new WaitForSeconds(1f);
        activatedGO.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        activatedGO.SetActive(false);
    }
    public void OnActivated()
    {
        isActive = !isActive;
        activatedGO.SetActive(isActive);
    }
}
