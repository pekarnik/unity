﻿using System;
using Game;
namespace Tests
{
    class HeadBot:BaseObjectScene,ISetDamage
    {
        public event Action<InfoCollision> OnApplyDamageChange;
        public void SetDamage(InfoCollision info)
        {
            OnApplyDamageChange?.Invoke(new InfoCollision(info.Damage*500,info.Contact,info.ObjCollision,info.Dir));
        }
    }
}
