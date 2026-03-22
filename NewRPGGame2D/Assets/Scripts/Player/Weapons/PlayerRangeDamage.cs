using UnityEngine;

namespace PlayerBehaviour
{
    public class PlayerRangeDamage : MonoBehaviour
    {
        public int rangeDamage;
        public GameObject fx;

        private void Start()
        {
            Invoke(nameof(OnSelfDeath), 2f);
        }
        public void OnSelfDeath()
        {
            Instantiate(fx, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
