using System;
using UnityEngine;

namespace Game
{
    public class Aim:MonoBehaviour,ISetDamage
    {
        public event Action OnPointChange;

        private int timeToDissapear = 10;
        public float Hp = 100;
        private bool _isDead;
        //дописать поглощение урона
        public void SetDamage(InfoCollision info)
        {
            if (_isDead) return;
            if(Hp>0)
            {
                Hp -= info.Damage;
            }
            if(Hp<=0)
            {
                var tempRigidBody = GetComponent<Rigidbody>();
                if(!tempRigidBody)
                {
                    tempRigidBody = gameObject.AddComponent<Rigidbody>();
                }
                tempRigidBody.velocity = info.Dir;
                Destroy(gameObject, timeToDissapear);

                OnPointChange?.Invoke();
                _isDead = true;
            }
        }
    }
}
