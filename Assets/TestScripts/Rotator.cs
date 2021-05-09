using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestScripts
{
    public enum TypeRotate
    {
        LookRotate,
        RotateTowards
    }
    public class Rotator : MonoBehaviour
    {
        [SerializeField] private TypeRotate _type;
        [SerializeField] private float _speed;
        [SerializeField] private Transform _target;

        void Update()
        {
            switch (_type)
            {
                case TypeRotate.LookRotate:
                    LookRotate();
                    break;
                case TypeRotate.RotateTowards:
                    RotateTowards();
                    break;
            }
        }

        private void LookRotate() =>
            transform.rotation = Quaternion.LookRotation(_target.position - transform.position);
    
        private void RotateTowards()
        {
            var dir = _target.position - transform.position;
            var newDir = Vector3.RotateTowards(transform.forward, dir, _speed * Time.deltaTime, 0f);
            transform.rotation = Quaternion.LookRotation(newDir);
        }
    }
}
