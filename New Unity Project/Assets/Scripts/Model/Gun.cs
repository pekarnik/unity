using UnityEngine;
namespace Game
{
    class Gun : Weapons
    {
        public override void Fire(Ammunition ammunition)
        {
            if (_fire) 
                if(ammunition)
                {
                    Bullet tempbulet = Instantiate(ammunition, _gun.position, _gun.rotation) as Bullet;
                    if(tempbulet)
                    {
                        tempbulet.GetComponent<Rigidbody>().AddForce(_gun.forward * _force);
                        tempbulet.name = "Bullet";
                        _fire = false;
                        _recharge.Start(_rechargeTime);
                    }
                }
        }
    }
}
