using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerBehaviour
{
    public class PlayerMovement : MonoBehaviour
    {
        public float Speed;

        [SerializeField]
        private Transform attackHandTransform;
        private float _speed;
        private Rigidbody2D _rb;
        private Vector2 moveVector;
        private Animator _animator;
        private AudioSource audioSource;
        private bool _isEnemyOver;

        private List<GameObject> enemyList = new();
        public GameObject currentEnemy;

        void Start()
        {
            _speed = Speed;
            _isEnemyOver = false;
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            audioSource = GetComponent<AudioSource>();
        }
        public void InputPlayer(InputAction.CallbackContext _context)
        {
            moveVector = _context.ReadValue<Vector2>();
        }
        void Update()
        {
            MovementLogic();
        }
        private void MovementLogic()
        {
            Vector3 move = new(moveVector.x, moveVector.y, 0);
            move.Normalize();
            
            _rb.MovePosition(_rb.position + _speed * Time.deltaTime * moveVector);

            float anim = Mathf.Abs(moveVector.y) + Mathf.Abs(moveVector.x); ;
            _animator.SetFloat("Speed", anim);

            if (moveVector.x < 0)
            {
                OnPlayerRotate(0, -1, 180);
            }
            else if (moveVector.x > 0)
            {
                OnPlayerRotate(180, 1, 0);
            }

            //audioSource.volume = anim;
        }
        private void OnPlayerRotate(int rots, int vec, int vector)
        {
            Quaternion rot = transform.rotation;
            rot.y = rots;
            transform.rotation = rot;
           
            if (enemyList.Count != 0) 
            {
                OnClosestEnemySearch(enemyList);
                Vector3 mousePosition = currentEnemy.transform.position;

                Vector2 direction = mousePosition - transform.position;
                float angle = Vector2.SignedAngle(Vector2.right, direction);
                attackHandTransform.transform.localEulerAngles = new Vector3(0, 0, -vec * angle + vector);
                return;
            }
            Vector3 dir = (moveVector.x * vec * Vector3.up + Vector3.left * -moveVector.y);
            attackHandTransform.localRotation = Quaternion.LookRotation(Vector3.forward, dir);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<EnemyHealthSystem>())
            {
                enemyList.Add(collision.gameObject);
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.GetComponent<EnemyHealthSystem>())
            {
                enemyList.Remove(collision.gameObject);
            }
        }
        private void OnClosestEnemySearch(List<GameObject> enemies)
        {
            GameObject closestEnemy = null;
            var distance = Mathf.Infinity;
            var playerPos = transform.position;

            foreach (var enemy in enemies)
            {
                var diff = enemy.transform.position - playerPos;
                var currDistance = diff.sqrMagnitude;

                if (currDistance < distance)
                {
                    closestEnemy = enemy;
                    distance = currDistance;
                }
            }
            currentEnemy = closestEnemy;
            
        }
    }
}
