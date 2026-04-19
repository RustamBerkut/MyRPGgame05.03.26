using UnityEngine;
using UnityEngine.InputSystem;

public class FireRainSkill : MonoBehaviour, ISkill
{
    [SerializeField]
    private GameObject   fireRainFX;

    private int          skillLevel;
    private float        skillRadius;
    private int          skillDamage;

    private GameObject   player;
    private Collider2D[] objectsInsideArea;

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            OnFireRain();
        }
    }
    private void OnFireRain()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 point = new(mouseWorldPosition.x, mouseWorldPosition.y, 1);
        GameObject fx = Instantiate(fireRainFX, point, Quaternion.identity);
        fx.transform.localScale = new Vector3(skillLevel, skillLevel, 1);
        objectsInsideArea = Physics2D.OverlapCircleAll(mouseWorldPosition, skillRadius);
        foreach (var item in objectsInsideArea)
        {
            if (item.GetComponent<EnemyHealthSystem>())
            {
                //item.GetComponent<FireRainSkill>().OnFreezeSkillUse();
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
    }
}
