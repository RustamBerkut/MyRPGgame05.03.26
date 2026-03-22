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

        private float MeleeDamage;
        private float MagicDamage;
        private float RangeDamage;

        private float AttackSpeed;
        private float CritChance;
        private float CastSpeed;

        public List<GameObject> equipmentSlot;

        private int bonus_STR;
        private int bonus_DEX;
        private int bonus_INT;
        private int bonus_CON;

        private int bonus_meleeDamage;
        private int bonus_MagicDamage;
        private int bonus_RangeDamage;

        private int bonus_AttackSpeed;
        private int bonus_CritChance;
        private int bonus_CastSpeed;

        private int bonus_shield;
        private int bonus_hp;
        private int bonus_mp;

        private PlayerHealthSystem healthSystem;
        private PlayerManaSystem manaSystem;
        private PlayerAttack playerAttack;

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

            bonus_meleeDamage = 0;
            bonus_MagicDamage = 0;
            bonus_RangeDamage = 0;

            bonus_AttackSpeed = 0;
            bonus_CritChance = 0;
            bonus_CastSpeed = 0;

            bonus_shield = 0;
            bonus_hp = 0;
            bonus_mp = 0;

            for (int i = 0; i < equipmentSlot.Count; i++)
            {
                if (equipmentSlot[i].GetComponentInChildren<UIItem>()) 
                {
                    int _bonus_STR = equipmentSlot[i].GetComponentInChildren<UIItem>().STR;
                    int _bonus_DEX = equipmentSlot[i].GetComponentInChildren<UIItem>().DEX;
                    int _bonus_INT = equipmentSlot[i].GetComponentInChildren<UIItem>().INT;
                    int _bonus_CON = equipmentSlot[i].GetComponentInChildren<UIItem>().CON;

                    int _bonus_melee = equipmentSlot[i].GetComponentInChildren<UIItem>().meleeAttack;
                    int _bonus_magic = equipmentSlot[i].GetComponentInChildren<UIItem>().mageAttack;
                    int _bonus_range = equipmentSlot[i].GetComponentInChildren<UIItem>().bowAttack;

                    int _bonus_attackSpeed = equipmentSlot[i].GetComponentInChildren<UIItem>().attackSpeed;
                    int _bonus_critChance = equipmentSlot[i].GetComponentInChildren<UIItem>().critChanse;
                    int _bonus_castspeed = equipmentSlot[i].GetComponentInChildren<UIItem>().castSpeed;

                    int _bonus_shield = equipmentSlot[i].GetComponentInChildren<UIItem>().shield;
                    int _bonus_hp = equipmentSlot[i].GetComponentInChildren<UIItem>().HP;
                    int _bonus_mp = equipmentSlot[i].GetComponentInChildren<UIItem>().MP;

                    bonus_STR += _bonus_STR;
                    bonus_DEX += _bonus_DEX;
                    bonus_INT += _bonus_INT;
                    bonus_CON += _bonus_CON;

                    bonus_meleeDamage += _bonus_melee;
                    bonus_MagicDamage += _bonus_magic;
                    bonus_RangeDamage += _bonus_range;

                    bonus_AttackSpeed += _bonus_attackSpeed;
                    bonus_CritChance += _bonus_critChance;
                    bonus_CastSpeed += _bonus_castspeed;

                    bonus_shield += _bonus_shield;
                    bonus_hp += _bonus_hp;
                    bonus_mp += _bonus_mp;
                }
                OnStatsUpdate();
            }
        }

        private void Start()
        {
            healthSystem = GetComponent<PlayerHealthSystem>();
            manaSystem = GetComponent<PlayerManaSystem>();
            playerAttack = GetComponent<PlayerAttack>();
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

            healthSystem.SetupMaxHp(CON + bonus_CON, bonus_hp);
            manaSystem.SetupMaxMp(INT + bonus_INT, bonus_mp);
            healthSystem.OnShieldSetup(bonus_shield);

            MeleeDamage = 10 + (STR - 10 + bonus_STR) * 0.5f + bonus_meleeDamage;
            MagicDamage = 15 * (1 + (INT - 10 + bonus_INT) * 0.05f) + bonus_MagicDamage;
            RangeDamage = 10 + (DEX - 10 + bonus_DEX) * 0.5f + bonus_RangeDamage;

            AttackSpeed = 1.0f + (DEX - 10 + bonus_DEX) * 0.02f + bonus_AttackSpeed;
            CritChance = 0.05f + (DEX - 10 + bonus_DEX) * 0.003f + bonus_CritChance;
            CastSpeed = 1.0f + (INT - 10 + bonus_INT) * 0.02f + bonus_CastSpeed;


            playerAttack.OnAttackStatSetup(MeleeDamage, MagicDamage, RangeDamage, 
                AttackSpeed, CritChance, CastSpeed);
            
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
            OnStatsUpdate();
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

            OnStatsUpdate();
            statFreePoints += value - 5;
            OnSetupPlayerStatpoints();
            SetupStatsInText();
        }
    }
}