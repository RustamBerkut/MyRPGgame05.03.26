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
        [SerializeField]
        private Transform rangeBarrel;

        [SerializeField]
        private GameObject _arrow;
        [SerializeField]
        private GameObject _charge;

        private void Start()
        {
            swordBoxCollider.enabled = false;
            dualBoxCollider.enabled = false;
            trailSword.SetActive(false);
            trailDual.SetActive(false);
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
        public void OnBowDamage()
        {
            GameObject arrow = Instantiate(_arrow, rangeBarrel.transform.position, rangeBarrel.transform.rotation);
            arrow.GetComponent<Rigidbody2D>().AddForce(arrow.transform.right * - 500);
        }
        public void OnMageDamage()
        {
            GameObject arrow = Instantiate(_charge, rangeBarrel.transform.position, rangeBarrel.transform.rotation);
            arrow.GetComponent<Rigidbody2D>().AddForce(arrow.transform.right * -500);
        }
    }
}
