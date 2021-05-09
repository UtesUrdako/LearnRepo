using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace student
{
    public class Charapter : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private float speed = 2f;
        [SerializeField] private float _MouseSensetive;
        [SerializeField] private Transform _camera;
        [SerializeField] private AudioSource swordsound;
        [SerializeField] private AudioSource fight;
        [SerializeField] private GameObject prefab;
        [SerializeField] private GameObject magic;
        [SerializeField] private Animator _animator;
        public float health = 1000f;
        private bool ishield = true;
        Component sword;
        [SerializeField] bool rayCast;
        Vector3 _direction = Vector3.zero;
        Quaternion m_Rotation;
        private float damage;
        float ang;
        float _angle;
        private Rigidbody rg;
        private bool up = false;

        private void Awake()
        {

            rg = GetComponent<Rigidbody>();
        }

        void Update()
        {
            rayCast = Physics.Raycast(transform.position + Vector3.up / 100, Vector3.down, 0.5f);
            Debug.DrawRay(transform.position, Vector3.down, Color.green, 3f);

            _direction.x = Input.GetAxis("Horizontal");
            _direction.z = Input.GetAxis("Vertical");
            _direction = _direction.normalized;
            _angle = Input.GetAxis("Mouse X");
            Camerarotator();
            NewMethod();

        }

        private void NewMethod()
        {
            if (Input.GetButtonDown("Jump") && rayCast)
            {
                rg.AddForce(Vector3.up * 400f, ForceMode.Impulse);
            }
        }

        private void FixedUpdate()
        {
            Move();
        }

        public Transform targ_;
        private void Camerarotator()
        {
            targ_.localPosition = new Vector3(_direction.x, player.transform.localPosition.y, _direction.z);
            player.transform.LookAt(targ_);
            _camera.transform.Rotate(new Vector3(0f, _angle * _MouseSensetive * Time.fixedDeltaTime, 0f));
        }

        private void Move()
        {
            if (ishield)
            {
                var _speed = _direction * Time.fixedDeltaTime * speed;
                transform.Translate(_speed);
            }
        }
    }
}
