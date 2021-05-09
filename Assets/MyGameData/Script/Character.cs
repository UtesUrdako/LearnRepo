using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, ITakeDamage
{
    [SerializeField] private float _mousSensetive = 3f;

    public float speed = 2f;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletSpawn;

    private new CapsuleCollider collider;
    [SerializeField] private Animator _animator;

    private float _boostDamage = 5f;
    private Vector3 _direction = Vector3.zero;
    private float _angle;

    [SerializeField] private int _health = 100;

    private void Awake()
    {
        speed = 3;
        collider = GetComponent<CapsuleCollider>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger("Fire");
        }

        //_direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");

        _angle = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }
    private void Move()
    {
        if (Mathf.Approximately(_direction.magnitude, 0f))
            _animator.SetBool("IsWalk", false);
        else
            _animator.SetBool("IsWalk", true);

        var _speed = _direction.normalized * Time.fixedDeltaTime * speed;
        transform.Translate(_speed);
    }

    private void Rotate()
    {
        transform.Rotate(new Vector3(0f, _angle * _mousSensetive * Time.fixedDeltaTime, 0f));
    }

    private void Fire(Object prefab)
    {
        var bullet = GameObject.Instantiate((prefab as GameObject), bulletSpawn.transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().Booster(_boostDamage);
        //bullet.SetActive(false);
    }

    public void Damage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
            _animator.SetTrigger("Die");
    }
}
