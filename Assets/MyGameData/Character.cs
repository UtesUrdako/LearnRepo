using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace student
{
    public class Character : MonoBehaviour//, ITakeDamage, ITakeHealing
    {
        public float speed = 5f;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private GameObject bulletSpawn;
        [SerializeField] private float _mouseSensetive = 90f;
        [SerializeField] private int _health = 100;
        [SerializeField] private Transform _target;

        private int _boostDamage = 5;
        private Vector3 _direction = Vector3.zero;
        private float _angle;
        private new CapsuleCollider collider;
        [SerializeField] private Animator _animator;

        [SerializeField] public bool _iHaveAKey;

        private void Awake()
        {
            collider = GetComponent<CapsuleCollider>();
            _iHaveAKey = false;
            _animator = GetComponent<Animator>();
        }

        void Update()
        {
            _direction.z = -Input.GetAxis("Vertical");

            _angle = Input.GetAxis("Horizontal");

            if (Input.GetMouseButtonDown(0))
            {
                _animator.SetTrigger("isFire");
            }
        }

        private void FixedUpdate()
        {
            Move();
            Rotate();
        }

        private void Move()
        {
            if (Mathf.Approximately(_direction.magnitude, 0f))
                _animator.SetBool("isWalk", false);
            else
                _animator.SetBool("isWalk", true);

            var _speed = _direction.normalized * Time.fixedDeltaTime * speed;
            transform.Translate(_speed);
        }

        private void Rotate()
        {
            transform.Rotate(new Vector3(0f, _angle * _mouseSensetive * Time.fixedDeltaTime, 0f));
        }

        private void Fire(Object prefab)
        {
            var bullet = GameObject.Instantiate((prefab as GameObject), bulletSpawn.transform.position, Quaternion.identity);
            //bullet.GetComponent<PlayerBullet>().Booster(_boostDamage);
        }

        public void Damage(int damage)
        {
            if (_health > damage)
                _health -= damage;
            else
                _animator.SetTrigger("isDie");
        }


        public void Healing(int healing)
        {
            if (_health >= 100 - healing)
                _health = 100;
            else
                _health += healing;
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.tag == "Key")
            {
                _iHaveAKey = true;
                Destroy(collision.gameObject);
            }
        }

        private void OnCollisionStay(Collision other)
        {
            if (other.gameObject.tag == "Door" && _iHaveAKey == true)
                Destroy(other.gameObject);
        }

    }
}
