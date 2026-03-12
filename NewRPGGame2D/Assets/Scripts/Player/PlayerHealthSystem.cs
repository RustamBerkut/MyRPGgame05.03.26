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
        
        private int MaxHP;
        private int currentHP;
        
        private int HpRegen;
        private int playerCon = 10;
        private float timeRegen = 10;
        public float timeAfterAttack = 10;
        
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

        public void SetupMaxHp(int CON)
        {
            playerCon = CON;
            MaxHP = 100 + (CON - 10) * 5;
            currentHP = MaxHP;
            hpSlider.maxValue = currentHP;
            hpSlider.value = currentHP;
            HPText.text = string.Format("{0} / {1}", currentHP, MaxHP);
        }
        public void OnDamage(int damage)
        {
            currentHP -= damage;
            hpSlider.value = currentHP;
            timeAfterAttack = 10;
            HPText.text = string.Format("{0} / {1}", currentHP, MaxHP);
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
            HPText.text = string.Format("{0} / {1}", currentHP, MaxHP);
            hpSlider.value = currentHP;
        }
        private void OnPlayerHealthRegen()
        {
            HpRegen = 2 + (playerCon - 10);
            timeRegen = 10;
            OnHealth(HpRegen);
        }
        private void OnPlayerDead()
        {
            Debug.Log("Player dead");
        }
    }
}
