using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurrel : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletSpawn;
    [SerializeField] private float _time = 1f;
    [SerializeField] private AudioSource _shootSource;
    [SerializeField] private ParticleSystem _shootEffect;

    private Transform _target;
    private float _timer;

    void Awake()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
        _shootSource = GetComponentInChildren<AudioSource>();
        _shootEffect = GetComponentInChildren<ParticleSystem>();
    }

    private void Start()
    {
        StartCoroutine(Fire(_time));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            StopFire();
    }

    private IEnumerator Fire(float time)
    {
        yield return new WaitForSeconds(3f);
        while (true)
        {
            RaycastHit hit;

            bool isHit = Physics.Raycast(_bulletSpawn.position, _bulletSpawn.forward, out hit, Mathf.Infinity);
            if (isHit && hit.collider.tag == "Player")
            {
                yield return new WaitForSeconds(_time);
                var bullet = GameObject.Instantiate(_bulletPrefab, _bulletSpawn.transform.position, _bulletSpawn.transform.rotation).GetComponent<Bullet>();
                bullet.Target = _target;

                _shootSource.Play();
                _shootEffect.Play();

                Debug.DrawRay(_bulletSpawn.position, _target.position, Color.green, _time);
            }
            else
            {
                Debug.DrawRay(_bulletSpawn.position, _target.position, Color.red);
                yield return null;
            }
        }
    }

    private void StopFire()
    {
        StopCoroutine(Fire(_time));
    }
}
