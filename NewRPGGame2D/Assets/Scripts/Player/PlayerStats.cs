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

        private void OnEnable()
        {
            UIItem.UpdateItemSlotAction += ItemStatReading;
        }
        private void OnDisable()
        {
            UIItem.UpdateItemSlotAction += ItemStatReading;
        }

        private void ItemStatReading()
        {
            Debug.Log("Stat read");
        }

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
                return;
            }

            // Установка характеристик
            OnStatsLoad();
            // Установка значений ХП МП
            OnStatsUpdate();
        }

        private void OnStatsLoad()
        {
            statFreePoints = PlayerPrefs.GetInt(statString);
            STR = PlayerPrefs.GetInt(strString);
            DEX = PlayerPrefs.GetInt(dexString);
            INT = PlayerPrefs.GetInt(intString);
            CON = PlayerPrefs.GetInt(conString);
        }
        private void OnStatsUpdate()
        {
            SetupStatsInText();

            healthSystem.SetupMaxHp(CON);
            manaSystem.SetupMaxMp(INT);

            MeleeDamage = 10 + (STR - 10) * 0.5f;
            MagicDamage = 15 * (1 + (INT - 10) * 0.05f);
            RangeDamage = 10 + (DEX - 10) * 0.5f;

            AttackSpeed = 1.0f + (DEX - 10) * 0.02f;
            CritChance = 0.05f + (DEX - 10) * 0.003f;
        }
        
        public void SetupStatsInText()
        {
            strText.text = STR.ToString();
            dexText.text = DEX.ToString();
            intText.text = INT.ToString();
            conText.text = CON.ToString();
            statText.text = statFreePoints.ToString();

            OnSaveStats();
        }
        private void OnSaveStats()
        {
            PlayerPrefs.SetInt(statString, statFreePoints);
            PlayerPrefs.SetInt(strString, STR);
            PlayerPrefs.SetInt(intString, INT);
            PlayerPrefs.SetInt(dexString, DEX);
            PlayerPrefs.SetInt(conString, CON);
        }

        public void OnStatsSummary(int value)
        {
            if (statFreePoints > 0)
            {
                statFreePoints--;
                switch (value)
                {
                    case 1: STR++;
                        break;
                    case 2: DEX++;
                        break;
                    case 3: INT++;
                        break;
                    case 4: CON++;
                        break;
                }
            }
            healthSystem.SetupMaxHp(CON);
            manaSystem.SetupMaxMp(INT);
            SetupStatsInText();
        }

        public void OnSetupPlayerStatpoints()
        {
            statFreePoints += 5;
            statText.text = statFreePoints.ToString();
            PlayerPrefs.SetInt(statString, statFreePoints);
        }
        public void OnStatPointClear()
        {
            int value = STR + DEX + INT + CON - 40;
            STR = 10;
            INT = 10;
            DEX = 10;
            CON = 10;

            healthSystem.SetupMaxHp(CON);
            manaSystem.SetupMaxMp(INT);
            statFreePoints += value - 5;
            OnSetupPlayerStatpoints();
            SetupStatsInText();
        }
    }
}