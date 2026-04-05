using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PlayerBehaviour;
using System;

public class EnemyHealthSystem : MonoBehaviour
{
    [SerializeField]
    private Slider hpSlider;
    [SerializeField]
    private TextMeshProUGUI HPText;
    [SerializeField]
    private GameObject enemyDamageCanvas;
    [SerializeField]
    private GameObject goldCoin;

    public float MaxHP;
    public GameObject fxHit;
    public float enemyExp;
    public float critChanse;

    public static Action<float, GameObject> EnemyDeadAction;

    private float currentHP;


    private void Start()
    {
        SetupMaxHp();
    }
    public void SetupMaxHp()
    {
        currentHP = (int)MaxHP;
        hpSlider.maxValue = currentHP;
        hpSlider.value = currentHP;
        HPText.text = string.Format("{0:0} / {1:0}", currentHP, MaxHP);
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
        float randomDamage = UnityEngine.Random.Range(damage * 0.7f, damage * 1.3f);

        currentHP -= randomDamage;
        hpSlider.value = currentHP;
                       
        GameObject can = Instantiate(enemyDamageCanvas, transform.position + new Vector3(0, 1, 0), transform.rotation);
        can.GetComponentInChildren<TextMeshProUGUI>().text = string.Format("{0:0}", (int)randomDamage);

        HPText.text = string.Format("{0:0} / {1:0}", currentHP, MaxHP);
        if (currentHP <= 0)
        {
            OnEnemyDead();
        }
    }
    private void OnEnemyDead()
    {
        Instantiate(goldCoin, transform.position, transform.rotation);
        EnemyDeadAction?.Invoke(enemyExp, gameObject);
        Destroy(gameObject);
    }
}