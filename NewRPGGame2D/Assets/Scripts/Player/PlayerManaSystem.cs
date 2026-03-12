using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace PlayerBehaviour
{
    public class PlayerManaSystem : MonoBehaviour
    {
        [SerializeField]
        private Slider mpSlider;
        [SerializeField]
        private TextMeshProUGUI MPText;

        private int MaxMP;
        private int currentMP;

        private int MpRegen;
        private int playerInt = 10;
        private float timeRegen = 1;
        public float timeAfterAttack = 10;

        private void Update()
        {
            timeAfterAttack -= Time.deltaTime;
            if (timeAfterAttack <= 0)
            {
                timeRegen -= Time.deltaTime;
                if (timeRegen <= 0)
                {
                    OnPlayerManaRegen();
                }
            }
        }

        public void SetupMaxMp(int INT)
        {
            playerInt = INT;
            MaxMP = 50 + (INT - 10) * 3;
            currentMP = MaxMP;
            mpSlider.maxValue = currentMP;
            mpSlider.value = currentMP;
            MPText.text = string.Format("{0} / {1}", currentMP, MaxMP);
        }
        public void OnMageAttack(int mpCost)
        {
            currentMP -= mpCost;
            mpSlider.value = currentMP;
            timeAfterAttack = 10;
            MPText.text = string.Format("{0} / {1}", currentMP, MaxMP);
            if (currentMP <= 0)
            {
                OnPlayerDead();
            }
        }
        public void OnMpUpdate(int regen)
        {
            currentMP += regen;
            if (currentMP >= MaxMP)
            {
                currentMP = MaxMP;
            }
            MPText.text = string.Format("{0} / {1}", currentMP, MaxMP);
            mpSlider.value = currentMP;
        }
        private void OnPlayerManaRegen()
        {
            MpRegen = 3 + (playerInt - 10);
            timeRegen = 1;
            OnMpUpdate(MpRegen);
        }
        private void OnPlayerDead()
        {
            Debug.Log("Player dead");
        }
    }
}
