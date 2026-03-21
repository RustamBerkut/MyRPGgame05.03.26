using UnityEngine;

namespace PlayerBehaviour
{
    public class PlayerDamager : MonoBehaviour
    {
        public int playerDamage;

        [SerializeField]
        private BoxCollider2D swordBoxCollider;

        private void Start()
        {
            swordBoxCollider.enabled = false;
        }

        public void OnSwordDamage()
        {
            swordBoxCollider.enabled = true;
        }
        public void OffSwordDamage()
        {
            swordBoxCollider.enabled = false;
        }
    }
}
