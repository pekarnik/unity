using UnityEngine;

namespace Game
{
    public class Bullet:Ammunition
    {
        [SerializeField] private float _timeToDestruct = 10;
        [SerializeField] private float _damage = 20;
        [SerializeField] private float _mass = 0.01f;

        private float _currentDamage;
        protected override void Awake()
        {
            base.Awake();
            Destroy(gameObject, _timeToDestruct);
            _currentDamage = _damage;
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.tag == "Bullet") return;
            Destroy(gameObject);
        }
        private void SetDamage(ISetDamage obj)
        {
            if (obj != null)
                obj.ApplyDamage(_currentDamage);
        }
    }
}
