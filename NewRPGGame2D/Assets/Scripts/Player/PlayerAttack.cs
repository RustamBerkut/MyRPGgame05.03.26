using UnityEngine;
using UnityEngine.InputSystem;

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
                    OnSwordAttack();
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
        private void OnSwordAttack()
        {
            animator.CrossFade("SwordAttackAnim", 0.1f);
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