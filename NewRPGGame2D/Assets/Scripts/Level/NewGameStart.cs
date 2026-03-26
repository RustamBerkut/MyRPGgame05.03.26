using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameStart : MonoBehaviour
{
    public GameObject activatedGO;
    public GameObject gameLoadingImage;

    private bool isActive;

    public void OnActivated()
    {
        isActive = !isActive;
        activatedGO.SetActive(isActive);
    }
    public void OnLoadingSceneByNumber()
    {
        gameLoadingImage.SetActive(true);
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
    }
}
