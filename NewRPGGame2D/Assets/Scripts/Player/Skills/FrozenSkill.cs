using UnityEngine;

public class FrozenSkill : MonoBehaviour, ISkill
{
    [SerializeField]  
    private GameObject player;
    [SerializeField]
    private float skillRadius;
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
        objectsInsideArea = Physics2D.OverlapCircleAll(player.transform.position, skillRadius);
        foreach (var item in objectsInsideArea)
        {
            Debug.Log("You damage the enemy");
        }
    }

}
