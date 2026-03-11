using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerBehaviour
{
    public class PlayerMovement : MonoBehaviour
    {
        public float Speed = 5f;

        [SerializeField]
        private Transform attackHandTransform;

        private Rigidbody2D _rb;
        private Vector2 moveVector;
        private Animator _animator;
        private AudioSource audioSource;

        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            audioSource = GetComponent<AudioSource>();
        }
        public void InputPlayer(InputAction.CallbackContext _context)
        {
            moveVector = _context.ReadValue<Vector2>();
        }
        void FixedUpdate()
        {
            MovementLogic();
        }
        private void MovementLogic()
        {
            Vector3 move = new(moveVector.x, moveVector.y, 0);
            move.Normalize();
            
            _rb.MovePosition(_rb.position + Speed * Time.deltaTime * moveVector);

            float anim = Mathf.Abs(moveVector.y) + Mathf.Abs(moveVector.x); ;
            _animator.SetFloat("Speed", anim);

            if (moveVector.x < 0)
            {
                Quaternion rot = transform.rotation;
                rot.y = 0;
                transform.rotation = rot;

                Vector3 dir = (Vector3.up * -moveVector.x + Vector3.left * -moveVector.y);
                attackHandTransform.localRotation = Quaternion.LookRotation(Vector3.forward, dir);
            }
            else if (moveVector.x > 0)
            {
                Quaternion rot = transform.rotation;
                rot.y = 180;
                transform.rotation = rot;
                Vector3 dir = (Vector3.up * moveVector.x + Vector3.left * -moveVector.y);
                attackHandTransform.localRotation = Quaternion.LookRotation(Vector3.forward, dir);
            }

            

            //audioSource.volume = anim;
        }
    }
}
