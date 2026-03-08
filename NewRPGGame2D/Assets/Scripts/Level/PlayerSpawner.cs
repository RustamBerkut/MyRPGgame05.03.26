using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    private void OnEnable()
    {
        OnPlayerSpawn();
    }

    private void OnPlayerSpawn()
    {
        var player = Resources.Load<GameObject>("Player/Player");
        Instantiate(player, transform.position, Quaternion.identity);
    }
}
