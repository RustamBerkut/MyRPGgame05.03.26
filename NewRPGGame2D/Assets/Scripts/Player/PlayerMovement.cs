using UnityEngine;

namespace PlayerBehaviour
{
    public class PlayerMovement : MonoBehaviour
    {
        public float Speed = 5f;
        public FixedJoystick joystick;

        private Rigidbody2D _rb;
        private Vector2 moveVector;

        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            MovementLogic();
        }
        private void MovementLogic()
        {
            moveVector.x = Input.GetAxis("Horizontal") + joystick.Horizontal;
            moveVector.y = Input.GetAxis("Vertical") + +joystick.Vertical;
            _rb.MovePosition(_rb.position + Speed * Time.deltaTime * moveVector);
        }
    }
}
