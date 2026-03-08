using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<InventorySlot> UIslots;
    public List<GameObject> uiItems;
    
    private void Start()
    {
       
    }
    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {

    }

    private void OnResourcesLooting(int lootNumbers, int rockNumbers,
                int meatNumbers, int rubinNumbers, int woolNumbers)
    {

        for (int i = 0; i < UIslots.Count; i++)
        {
            if (UIslots[i].GetComponentInChildren<UIItem>())
            {
                uiItems.Add(UIslots[i].transform.GetChild(0).gameObject);
            }
        }
        GameObject lumb = uiItems.Find(obj => obj.name == "UILumberItem(Clone)");
        if (lumb != null)
        {
            lumb.GetComponentInChildren<TextMeshProUGUI>().text = lootNumbers.ToString();
        }
        else
        {
            GameObject loot = Instantiate(Resources.Load("UILumberItem")) as GameObject;
            loot.GetComponentInChildren<TextMeshProUGUI>().text = lootNumbers.ToString();
            for (int i = 0; i < UIslots.Count; i++)
            {
                if (UIslots[i].transform.childCount == 0)
                {
                    loot.transform.SetParent(UIslots[i].transform);
                    loot.transform.localPosition = Vector3.zero;
                    break;
                }
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            UpdateWeaponLoot(other.gameObject);
            Destroy(other.gameObject);
        }
    }
    public void UpdateWeaponLoot(GameObject others)
    {
        /*
        var weaponLoot = others.GetComponent<LootWeapon>().UIWeapon.name;
        ameObject loot = Instantiate(Resources.Load(weaponLoot)) as GameObject;
        for (int i = 0; i < UIslots.Count; i++)
        {
            if (UIslots[i].transform.childCount == 0)
            {
                loot.transform.SetParent(UIslots[i].transform);
                loot.transform.localPosition = Vector3.zero;
                break;
            }
        }*/
    }
}
