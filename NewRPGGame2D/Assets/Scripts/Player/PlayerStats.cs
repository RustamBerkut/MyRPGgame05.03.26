using UnityEngine;
using TMPro;

namespace PlayerBehaviour
{
    public class PlayerStats : MonoBehaviour
    {
        public int statFreePoints = 5;
        public int STR;
        public int DEX;
        public int INT;
        public int CON;

        public TextMeshProUGUI strText, dexText, intText, conText, statText;

        [SerializeField]
        private string strString;
        [SerializeField]
        private string dexString;
        [SerializeField]
        private string intString;
        [SerializeField]
        private string conString;
        [SerializeField]
        private string statString;

        public float MeleeDamage;
        public float MagicDamage;
        public float RangeDamage;

        public float AttackSpeed;
        public float CritChance;

        private PlayerHealthSystem healthSystem;
        private PlayerManaSystem manaSystem;

        private void Start()
        {
            healthSystem = GetComponent<PlayerHealthSystem>();
            manaSystem = GetComponent<PlayerManaSystem>();
            OnLoadingStats();
        }

        public void OnLoadingStats()
        {
            if (!PlayerPrefs.HasKey(statString))
            {
                OnStatsUpdate();
                SetupStatsInText();
                return;
            }

            // Установка характеристик
            OnStatsLoad();

            // Установка значений ХП МП
            OnStatsUpdate();

            // Назначение тексту загруженных значений
            SetupStatsInText();
        }

        private void OnStatsLoad()
        {
            statFreePoints = PlayerPrefs.GetInt(statString);
            STR = PlayerPrefs.GetInt(strString);
            INT = PlayerPrefs.GetInt(intString);
            DEX = PlayerPrefs.GetInt(dexString);
            CON = PlayerPrefs.GetInt(conString);
        }
        private void OnStatsUpdate()
        {
            OnSaveStats();

            healthSystem.SetupMaxHp(CON);
            manaSystem.SetupMaxMp(INT);

            

            MeleeDamage = 10 + (STR - 10) * 0.5f;
            MagicDamage = 15 * (1 + (INT - 10) * 0.05f);
            RangeDamage = 10 + (DEX - 10) * 0.5f;

            AttackSpeed = 1.0f + (DEX - 10) * 0.02f;
            CritChance = 0.05f + (DEX - 10) * 0.003f;
        }
        public void OnSaveStats()
        {
            PlayerPrefs.SetInt(statString, statFreePoints);
            PlayerPrefs.SetInt(strString, STR);
            PlayerPrefs.SetInt(intString, INT);
            PlayerPrefs.SetInt(dexString, DEX);
            PlayerPrefs.SetInt(conString, CON);
        }
        private void SetupStatsInText()
        {
            strText.text = STR.ToString();
            dexText.text = DEX.ToString();
            intText.text = INT.ToString();
            conText.text = CON.ToString();
            statText.text = statFreePoints.ToString();
        }
    }
}