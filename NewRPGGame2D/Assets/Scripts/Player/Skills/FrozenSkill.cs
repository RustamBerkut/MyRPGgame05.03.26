using UnityEngine;

public class FrozenSkill : MonoBehaviour, ISkill
{
    [SerializeField]  
    private GameObject player;
    [SerializeField]
    private Vector2 skillRadius;
    [SerializeField]
    private int skillDamage;
    [SerializeField] 
    private Collider2D[] objectsInsideArea;

    public void OnSkillUse()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        OnFrozen();
    }
    private void OnFrozen()
    {
        objectsInsideArea = Physics2D.OverlapAreaAll(player.transform.position, skillRadius);
        foreach (var item in objectsInsideArea)
        {
            Debug.Log(item.name);
        }
    }
}
