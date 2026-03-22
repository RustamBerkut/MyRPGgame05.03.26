using UnityEngine;

namespace PlayerBehaviour
{
    public class PlayerDamager : MonoBehaviour
    {
        public int playerDamage;

        [SerializeField]
        private BoxCollider2D swordBoxCollider;
        [SerializeField]
        private GameObject trailSword;
        [SerializeField]
        private BoxCollider2D dualBoxCollider;
        [SerializeField]
        private GameObject trailDual;

        private void Start()
        {
            swordBoxCollider.enabled = false;
            trailSword.SetActive(false);
        }

        public void OnSwordDamage()
        {
            swordBoxCollider.enabled = true;
            trailSword.SetActive(true);
        }
        public void OffSwordDamage()
        {
            swordBoxCollider.enabled = false;
            trailSword.SetActive(false);
        }
        public void OnDualDamage()
        {
            dualBoxCollider.enabled = true;
            trailDual.SetActive(true);
        }
        public void OffDualDamage()
        {
            dualBoxCollider.enabled = false;
            trailDual.SetActive(false);
        }
    }
}
