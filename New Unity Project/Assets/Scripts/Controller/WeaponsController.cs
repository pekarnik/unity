using UnityEngine;

namespace Game
{
    public class WeaponsController : BaseController
    {
        private Weapons _weapons;
        private Ammunition _ammunition;
        private int _mouseButton = (int)Main.MouseButton.LeftButton;
        public Weapons SelectedWeapons
        {
            get { return _weapons; }
        }
        public override void OnUpdate()
        {
            if (!IsActive) return;
            if (Input.GetMouseButton(_mouseButton))
            {
                SelectedWeapons.Fire(_ammunition);
            }
        }
        public virtual void On(Weapons weapons, Ammunition ammunition)
        {
            if (IsActive) return;
            base.On();
            _weapons = weapons;
            _ammunition = ammunition;
            _weapons.enabled = true;
        }
        public override void Off()
        {
            if (IsActive) return;
            base.Off();
            _weapons.enabled = false;
            _weapons = null;
            _ammunition = null;
        }
    }
}

