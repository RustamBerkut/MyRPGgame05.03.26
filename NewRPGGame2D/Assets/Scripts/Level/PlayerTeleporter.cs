using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTeleporter : MonoBehaviour
{
    public byte levelNumber;
    public GameObject fxTeleport;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LoadingSceneByNumber(levelNumber);
        }
    }
    public void LoadingSceneByNumber(int value)
    {
        SceneManager.LoadScene(value);
    }
}
