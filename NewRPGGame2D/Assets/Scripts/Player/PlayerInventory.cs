using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PlayerBehaviour
{
    public class PlayerInventory : MonoBehaviour
    {
        public List<InventorySlot> UIslots;
        public List<GameObject> uiItems;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<LootingItem>())
            {
                OnTakeLoot(collision.gameObject);
                Destroy(collision.gameObject);
            }
        }
        private void OnTakeLoot(GameObject looting)
        {
            var itemsLoot = looting.GetComponent<LootingItem>().UIItem.name;
            itemsLoot = string.Format("Loot/{0}", itemsLoot);
            var playerLoot = Resources.Load<GameObject>(itemsLoot);
            GameObject loot = Instantiate(playerLoot, transform.position, Quaternion.identity);
            for (int i = 0; i < UIslots.Count; i++)
            {
                if (UIslots[i].transform.childCount == 0)
                {
                    loot.transform.SetParent(UIslots[i].transform);
                    loot.transform.localPosition = Vector3.zero;
                    break;
                }
                else 
                {
                    Debug.Log("Ytn mesta");
                }
            }
        }
    }
}
