using System.Collections;
using TMPro;
using UnityEngine;

namespace PlayerBehaviour
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField]
        private GameObject equipmnetSlot;
        [SerializeField]
        private GameObject attackSlot;
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

            attackSlot.GetComponent<PlayerDamager>().playerDamage = (int)_meleeDamage;
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
                    StartCoroutine(nameof(OnBowAttack));
                    break;
                case Resours.Dual:
                    StartCoroutine(nameof(OnDualAttack));
                    break;
                case Resours.Mage:
                    StartCoroutine(nameof(OnMageAttack));
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
            attackSlot.GetComponent<PlayerDamager>().playerDamage = (int)_meleeDamage;
            animator.speed = _attackSpeed;
            animator.SetBool("Sword", true);
            yield return new WaitForSeconds(0.3f);
            animator.SetBool("Sword", false);
        }
        IEnumerator OnBowAttack()
        {
            attackSlot.GetComponent<PlayerDamager>().playerDamage = (int)_rangeDamage;
            animator.speed = _attackSpeed;
            animator.SetBool("Bow", true);
            yield return new WaitForSeconds(0.3f);
            animator.SetBool("Bow", false);
        }
        IEnumerator OnDualAttack()
        {
            attackSlot.GetComponent<PlayerDamager>().playerDamage = (int)_meleeDamage;
            animator.speed = _attackSpeed;
            animator.SetBool("Dual", true);
            yield return new WaitForSeconds(0.3f);
            animator.SetBool("Dual", false);
        }
        IEnumerator OnMageAttack() 
        {
            attackSlot.GetComponent<PlayerDamager>().playerDamage = (int)_magicDamage;
            animator.speed = _castSpeed;
            animator.SetBool("Mage", true);
            yield return new WaitForSeconds(0.3f);
            animator.SetBool("Mage", false);
        }
    }
}