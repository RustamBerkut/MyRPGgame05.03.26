using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace PlayerBehaviour
{
    public class PlayerHealthSystem : MonoBehaviour
    {
        [SerializeField]
        private Slider hpSlider;
        [SerializeField]
        private TextMeshProUGUI HPText;
        [SerializeField]
        private TextMeshProUGUI HPRegenText;
        [SerializeField]
        private TextMeshProUGUI ShieldText;

        private int MaxHP;
        private int currentHP;
        
        private int HpRegen;
        private int playerCon = 10;
        private float timeRegen = 10;
        public float timeAfterAttack = 10;

        private float playerShield;
        
        private void Update()
        {
            timeAfterAttack -= Time.deltaTime;
            if (timeAfterAttack <= 0)
            {
                timeRegen -= Time.deltaTime;
                if (timeRegen <= 0)
                {
                    OnPlayerHealthRegen();
                }
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<EnemyDamage>())
            {
                int dam = collision.gameObject.GetComponent<EnemyDamage>().EnemyDamager;
                OnDamage(dam);
            }
        }

        public void SetupMaxHp(int CON, int _health)
        {
            playerCon = CON;
            MaxHP = 100 + (CON - 10) * 5 + _health;
            currentHP = MaxHP;
            hpSlider.maxValue = currentHP;
            hpSlider.value = currentHP;
            HPText.text = string.Format("{0:0} / {1:0}", currentHP, MaxHP);
            OnPlayerHealthRegen();
        }
        public void OnShieldSetup(int _shield)
        {
            playerShield = _shield;
            playerShield /= (playerShield + 150);
            ShieldText.text = string.Format("Броня: {0:0}", _shield);
        }
        public void OnDamage(int damage)
        {
            float dam = damage * (1 - playerShield);
            currentHP -= (int)dam;
            hpSlider.value = currentHP;
            timeAfterAttack = 10;
            HPText.text = string.Format("{0:0} / {1:0}", currentHP, MaxHP);
            if (currentHP <= 0)
            {
                OnPlayerDead();
            }
        }
        public void OnHealth(int health)
        {
            currentHP += health;
            if (currentHP >= MaxHP)
            {
                currentHP = MaxHP;
            }
            HPText.text = string.Format("{0:0} / {1:0}", currentHP, MaxHP);
            hpSlider.value = currentHP;
        }
        private void OnPlayerHealthRegen()
        {
            HpRegen = 2 + (playerCon - 10);
            HPRegenText.text = string.Format("Реген здоровья: {0:0} ", HpRegen);
            timeRegen = 10;
            OnHealth(HpRegen);
        }
        private void OnPlayerDead()
        {
            Debug.Log("Player dead");
        }
    }
}
