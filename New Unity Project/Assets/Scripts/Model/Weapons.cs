using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public abstract class Weapon:BaseObjectScene
    {
        private int maxCountAmmunition = 20;
        private int _countClip = 5;
        public Ammunition Ammunition;
        public Clip Clip;

        protected AmmunitionType[] ammunitionType = new AmmunitionType[] { AmmunitionType.Bullet };

        [SerializeField] protected Transform _barrel;
        [SerializeField] protected float _force = 999;
        [SerializeField] protected float _rechargeTime = 0.2f;
        private Queue<Clip> _clips = new Queue<Clip>();

        protected bool _isReady = true;
        //protected Timer _timer = new Timer();

        private void Start()
        {
            for(var i=0;i<= _countClip; i++)
            {
                AddClip(new Clip { CountAmmunition = maxCountAmmunition });
            }

            ReloadClip();
        }
        public abstract void Fire();

        //protected virtual void Update()
        //{
        //    _timer.Update();
        //    if(_timer.IsEvent())
        //    {
        //        ReadyShoot();
        //    }
        //}

        protected void ReadyShoot()
        {
            _isReady = true;
        }

        protected void AddClip(Clip clip)
        {
            _clips.Enqueue(clip);
        }

        public void ReloadClip()
        {
            if (_countClip <= 0) return;
            Clip = _clips.Dequeue();
        }

        public int CountClip => _clips.Count;
    }
}
