using Game;
using UnityEngine;
using UnityEngine.AI;
namespace Tests
{
    public sealed class Bot:BaseObjectScene
    {
        public float Hp = 100;
        public Transform Target { get; set; }
        public Vision Vision;
        public Weapon Weapon;//с разным оружием
        public NavMeshAgent Agent { get; private set; }

        private float _waitTime = 3;
        private bool _isDeath;
        private bool _isDetected;
        private bool _isReady = true;

        protected override void Awake()
        {
            base.Awake();
            Agent = GetComponent<NavMeshAgent>();
            var bodyBot = GetComponentInChildren<BodyBot>();
            if (bodyBot != null) bodyBot.OnApplyDamageChange += SetDamage;
            var headBot = GetComponentInChildren<BodyBot>();
            if (headBot != null) headBot.OnApplyDamageChange += SetDamage;
            Weapon = GetComponentInChildren<Weapon>();
        }
        public void Tick()
        {
            if (_isDeath) return;
            if(!_isDetected)
            {
                if(!Agent.hasPath)
                {
                    if(_isReady)
                    {
                        _isReady = false;
                        Agent.SetDestination(Patrol.GenericPoint(transform));
                        Agent.stoppingDistance = 0;                        
                    }
                    
                }
                if(Agent.remainingDistance<=Agent.stoppingDistance)//осмотреть местность
                {
                    Invoke(nameof(ReadyPatrol), _waitTime);
                }
                if (Vision.VisionM(transform,Target))
                {
                    _isDetected = true;
                }
            }
            else
            {
                Agent.SetDestination(Target.position);
                Agent.stoppingDistance = 2;
                if(Vision.VisionM(transform,Target))
                {
                    //остановиться
                    Weapon.Fire();
                }

                // Потеря персонажа
            }
        }
        public void SetDamage(InfoCollision info)
        {
            if(Hp>0)
            {
                Hp -= info.Damage;
            }

            if(Hp<=0)
            {
                _isDeath = true;
                Agent.enabled = false;
                foreach(var child in GetComponentsInChildren<Transform>())
                {
                    child.parent = null;
                    var tempRbChild = child.GetComponent<Rigidbody>();
                    if(!tempRbChild)
                    {
                        tempRbChild = child.gameObject.AddComponent<Rigidbody>();
                    }
                    Main.Instance.BotController.RemoveBotToList(this);
                    Destroy(child.gameObject, 10);
                }
            }
        }
        private void ReadyPatrol()
        {
            _isReady = true;
        }
        public void MovePoint(Vector3 point)
        {
            Agent.SetDestination(point);
        }
    }
}
