using UnityEngine;

public class FrozenSkill : MonoBehaviour, ISkill
{
    [SerializeField]
    private GameObject   iceFX;

    private int          skillLevel;
    private float        skillRadius;
    private int          skillDamage;

    private GameObject   player;
    private Collider2D[] objectsInsideArea;

    private void OnFrozen()
    {
        GameObject fx = Instantiate(iceFX, player.transform.position, Quaternion.identity);
        fx.transform.localScale = new Vector3(skillLevel * 0.3f, skillLevel * 0.3f, 1);
        objectsInsideArea = Physics2D.OverlapCircleAll(player.transform.position, skillRadius);
        foreach (var item in objectsInsideArea)
        {
            if (item.GetComponent<FrozenEnemySkill>())
            {
                item.GetComponent<FrozenEnemySkill>().OnFreezeSkillUse();
                item.GetComponent<EnemyHealthSystem>().OnDamage(skillDamage);
            }
        }
        Destroy(gameObject);
    }
    public void OnSetupSkillInfo(float radius, int damage, int level)
    {
        skillRadius = radius;
        skillDamage = damage;
        skillLevel = level;
        player = GameObject.FindGameObjectWithTag("Player");
        OnFrozen();
    }
}
