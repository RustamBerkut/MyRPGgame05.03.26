using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

namespace PlayerBehaviour
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField]
        private GameObject equipmnetSlot;
        [SerializeField]
        private Animator animator;
        [SerializeField]
        private GameObject noWeaponCanvas;

        public float  _meleeDamage, _magicDamage, _rangeDamage, _attackSpeed, _critChance, _castSpeed;

        [SerializeField]
        private TextMeshProUGUI meleeDamageText;
        [SerializeField]
        private TextMeshProUGUI magicDamageText;
        [SerializeField]
        private TextMeshProUGUI rangeDamageText;
        [SerializeField]
        private TextMeshProUGUI attackSpeedText;
        [SerializeField]
        private TextMeshProUGUI critChanceText;
        [SerializeField]
        private TextMeshProUGUI castSpeedText;
        public void OnAttackStatSetup(float melee, float magic, float range, float speed, 
            float crit, float cast)
        {
            _meleeDamage = melee;
            _magicDamage = magic;
            _rangeDamage = range;

            _attackSpeed = speed;
            _critChance = crit;
            _castSpeed = cast;

            meleeDamageText.text = string.Format("Ближний бой: {0:0}", _meleeDamage);
            magicDamageText.text = string.Format("Сила магии: {0:0}", _magicDamage);
            rangeDamageText.text = string.Format("Стрельба: {0:0}", _rangeDamage);
            attackSpeedText.text = string.Format("Скорость атаки: {0:0}", _attackSpeed);
            critChanceText.text = string.Format("Шанс крита: {0:0}", _critChance);
            castSpeedText.text = string.Format("Скорость каста: {0:0}", _castSpeed);
        }

        public void OnPlayerAttack()
        {
            if (equipmnetSlot.transform.childCount == 0)
            {
                Instantiate(noWeaponCanvas);
                return;
            }
            Resours resours = equipmnetSlot.GetComponentInChildren<UIItem>().resours;

            switch (resours)
            {
                case Resours.Sword:
                    StartCoroutine(nameof(OnSwordAttack));
                    break;
                case Resours.Bow:
                    OnBowAttack();
                    break;
                case Resours.Dual:
                    OnDualAttack();
                    break;
                case Resours.Mage:
                    OnMageAttack();
                    break;
                case Resours.Helmet:
                    break;
                case Resours.Shield:
                    break;
                case Resours.Body:
                    break;
                case Resours.Hand:
                    break;
                case Resours.Legs:
                    break;
                case Resours.HPpotion:
                    break;
                case Resours.MPpotion:
                    break;
                case Resours.Rune:
                    break;
                default:
                    break;
            }
        }
        IEnumerator OnSwordAttack()
        {
            animator.speed = 0.5f;
            animator.SetBool("Sword", true);
            yield return new WaitForSeconds(0.3f);
            animator.SetBool("Sword", false);
        }
        private void OnBowAttack()
        {
            Debug.Log("BowAttack");
        }
        private void OnDualAttack()
        {
            Debug.Log("DualAttack");
        }
        private void OnMageAttack() 
        {
            Debug.Log("MageAttack");
        }
    }
}