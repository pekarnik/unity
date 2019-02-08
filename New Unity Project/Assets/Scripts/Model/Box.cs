using UnityEngine;

namespace Game
{
    public class Box : BaseObjectScene, ISetDamage
    {
        [SerializeField] private float _hp = 100;
        private bool _isDead = false;
        private float step = 2f;
        private Material _material;
        protected override void Awake()
        {
            _material = gameObject.GetComponent<MeshRenderer>().material;
        }
        public void Dead(bool isDead)
        {
            if(isDead)
                Destroy(gameObject);
        }
        public void ApplyDamage(float currentDamage=0)
        {
            if(_hp>0)
            {
                _hp -= currentDamage;
            }
            else
            {
                _hp = 0;
                _isDead = true;
            }
            Dead(_isDead);
        }
    }
}
