using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PlayerBehaviour;

public class EnemyHealthSystem : MonoBehaviour
{
    [SerializeField]
    private Slider hpSlider;
    [SerializeField]
    private TextMeshProUGUI HPText;

    public int MaxHP;
    public GameObject fxHit;

    private int currentHP;

    private void Start()
    {
        SetupMaxHp();
    }
    public void SetupMaxHp()
    {
        currentHP = MaxHP;
        hpSlider.maxValue = currentHP;
        hpSlider.value = currentHP;
        HPText.text = string.Format("{0} / {1}", currentHP, MaxHP);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerDamager>())
        {
            int damage = collision.gameObject.GetComponent<PlayerDamager>().playerDamage;
            Instantiate(fxHit, transform.position, transform.rotation);
            OnDamage(damage);
        }
        if (collision.gameObject.GetComponent<PlayerRangeDamage>())
        {
            int damage = collision.gameObject.GetComponent<PlayerRangeDamage>().rangeDamage;
            OnDamage(damage);
            collision.GetComponent<PlayerRangeDamage>().OnSelfDeath();
        }
    }

    private void OnDamage(int damage)
    {
        currentHP -= damage;
        hpSlider.value = currentHP;
        HPText.text = string.Format("{0} / {1}", currentHP, MaxHP);
        if (currentHP <= 0)
        {
            OnEnemyDead();
        }
    }
    private void OnEnemyDead()
    {
        Destroy(gameObject);
    }
}
