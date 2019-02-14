using System;
using Game;
namespace Tests
{
    class BodyBot:BaseObjectScene,ISetDamage
    {
        public event Action<InfoCollision> OnApplyDamageChange;
        public void SetDamage(InfoCollision info)
        {
            OnApplyDamageChange.Invoke(info);
        }
    }
}
