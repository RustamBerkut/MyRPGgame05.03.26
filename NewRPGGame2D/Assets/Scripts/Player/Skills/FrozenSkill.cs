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
    [SerializeField]
    private GameObject iceFX;
    [SerializeField]
    private int skillLevel;

    public void OnSkillUse()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        OnFrozen();
    }
    private void OnFrozen()
    {
        GameObject fx = Instantiate(iceFX, player.transform.position, Quaternion.identity);
        fx.transform.localScale = new Vector3(skillLevel * 0.5f, skillLevel * 0.5f, 1);
        objectsInsideArea = Physics2D.OverlapCircleAll(player.transform.position, skillRadius);
        foreach (var item in objectsInsideArea)
        {
            if (item.GetComponent<FrozenEnemySkill>())
            {
                item.GetComponent<FrozenEnemySkill>().OnFreezeSkillUse();
                item.GetComponent<EnemyHealthSystem>().OnDamage(skillDamage);
            }
        }
    }
}
