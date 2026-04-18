using UnityEngine;

public class FrozenSkill : MonoBehaviour, ISkill
{
    public float         coolDownTime;

    [SerializeField]
    private float        skillRadius;
    [SerializeField]
    private int          skillDamage;
    [SerializeField]
    private GameObject   iceFX;
    [SerializeField]
    private int          skillLevel;

    private GameObject   player;
    private Collider2D[] objectsInsideArea;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        OnFrozen();
    }
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
}
