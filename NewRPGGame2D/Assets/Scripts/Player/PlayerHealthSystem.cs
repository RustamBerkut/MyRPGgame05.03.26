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
        private int MaxHP;

        private int currentHP;


        public void SetupMaxHp(int CON)
        {
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
            HPText.text = string.Format("{0} / {1}", currentHP, MaxHP);
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                OnDamage(10);
            }
        }
    }
}
