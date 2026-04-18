using UnityEngine;
using UnityEngine.InputSystem;

public class TeleportSkill : MonoBehaviour
{
    [SerializeField]
    private GameObject teleportFX;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }
    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            OnPlayerTeleport();
        }

    }
    private void OnPlayerTeleport()
    {
        Instantiate(teleportFX, player.transform.position, Quaternion.identity);
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        player.transform.position = new Vector2(mouseWorldPosition.x, mouseWorldPosition.y);
        Destroy(gameObject);
    }
}
