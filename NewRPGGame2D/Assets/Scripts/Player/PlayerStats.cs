using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

        public List<GameObject> equipmentSlot;

        public int bonus_STR;
        public int bonus_DEX;
        public int bonus_INT;
        public int bonus_CON;

        private PlayerHealthSystem healthSystem;
        private PlayerManaSystem manaSystem;

        private void OnEnable()
        {
            UIItem.UpdateItemStatAction += ItemStatReading;
        }
        private void OnDisable()
        {
            UIItem.UpdateItemStatAction -= ItemStatReading;
        }

        private void ItemStatReading()
        {
            bonus_STR = 0;
            bonus_DEX = 0;
            bonus_INT = 0;
            bonus_CON = 0;

            for (int i = 0; i < equipmentSlot.Count; i++)
            {
                if (equipmentSlot[i].GetComponentInChildren<UIItem>()) 
                {
                    int _bonus_STR = equipmentSlot[i].GetComponentInChildren<UIItem>().STR;
                    int _bonus_DEX = equipmentSlot[i].GetComponentInChildren<UIItem>().DEX;
                    int _bonus_INT = equipmentSlot[i].GetComponentInChildren<UIItem>().INT;
                    int _bonus_CON = equipmentSlot[i].GetComponentInChildren<UIItem>().CON;

                    bonus_STR += _bonus_STR;
                    bonus_DEX += _bonus_DEX;
                    bonus_INT += _bonus_INT;
                    bonus_CON += _bonus_CON;
                }
                OnStatsUpdate();
            }
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

            healthSystem.SetupMaxHp(CON + bonus_CON);
            manaSystem.SetupMaxMp(INT + bonus_INT);

            MeleeDamage = 10 + (STR - 10 + bonus_STR) * 0.5f;
            MagicDamage = 15 * (1 + (INT - 10 + bonus_INT) * 0.05f);
            RangeDamage = 10 + (DEX - 10 + bonus_DEX) * 0.5f;

            AttackSpeed = 1.0f + (DEX - 10 + bonus_DEX) * 0.02f;
            CritChance = 0.05f + (DEX - 10 + bonus_DEX) * 0.003f;
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
            healthSystem.SetupMaxHp(CON + bonus_CON);
            manaSystem.SetupMaxMp(INT + bonus_INT);
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

            healthSystem.SetupMaxHp(CON + bonus_CON);
            manaSystem.SetupMaxMp(INT + bonus_INT);
            statFreePoints += value - 5;
            OnSetupPlayerStatpoints();
            SetupStatsInText();
        }
    }
}