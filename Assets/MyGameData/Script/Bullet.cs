using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    private float _damage = 3f;
    private Transform _target;
    private Vector3 _targetPosition;

    public Transform Target
    {
        set
        {
            _target = value;
            _targetPosition = _target.position;
        }
    }

    void Start()
    {
        Destroy(gameObject, 30f);
    }

    private void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime);// .position = Vector3.MoveTowards(transform.position, _targetPosition + Vector3.up, _speed * Time.deltaTime);
    }

    /// <summary>
    /// Усиление урона
    /// </summary>
    /// <param name="newDamage">новый урон</param>
    public void Booster(float newDamage)
    {
        _damage = newDamage;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<ITakeDamage>().Damage((int)_damage);
        }
    }
}
