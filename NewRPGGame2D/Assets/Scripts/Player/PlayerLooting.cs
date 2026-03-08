using UnityEngine;

public class PlayerLooting : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<LootingItem>())
        {
            OnTakeLoot();
        }
    }
    private void OnTakeLoot()
    {
        Debug.Log("Takeitnigga");
    }
    
}
