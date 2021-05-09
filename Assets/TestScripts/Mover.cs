using UnityEngine;

namespace TestScripts
{
    public enum TypeMoove
    {
        Towards,
        Slerp
    }

    public class Mover : MonoBehaviour
    {
        [SerializeField] private TypeMoove _type;
        [SerializeField] private float _speed;
        [SerializeField] private Transform _target;

        public void Init(Transform target) =>
            _target = target;

        void Update()
        {
            switch (_type)
            {
                case TypeMoove.Towards:
                    Towards();
                    break;
                case TypeMoove.Slerp:
                    Slerp();
                    break;
            }
        }

        private void Towards()
        {
            transform.position = Vector3.MoveTowards(transform.position,
                                                     _target.position,
                                                     _speed * Time.deltaTime);
        }

        private void Slerp()
        {
            transform.position = Vector3.Slerp(transform.position,
                                                     _target.position,
                                                     _speed * Time.deltaTime);
        }
    }
}
