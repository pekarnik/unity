using UnityEngine;
using Game.Helpers;
namespace Game
{
    public abstract class Weapons : BaseObjectScene
    {
        [SerializeField] protected Transform _gun;
        [SerializeField] protected float _force = 500;
        [SerializeField] protected float _rechargeTime = 0.2f;
        protected Timer _recharge = new Timer();
        protected bool _fire = true;
        public abstract void Fire(Ammunition ammunition);
        protected virtual void Update()
        {
            _recharge.Update();
            if(_recharge.IsEvent())
            {
                _fire = true;
            }
        }
    }
}