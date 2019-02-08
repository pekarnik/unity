using UnityEngine;

namespace Game
{ 
	public class InputController:BaseController
	{
		private KeyCode _codeFlashLight = KeyCode.F;
		private KeyCode _use = KeyCode.E;
        private bool _isSelectWeapons = true;
        private int _indexWeapons = 0;
		public override void OnUpdate()
		{
			if (!IsActive) return;
			if(Input.GetKeyDown(_codeFlashLight))
				Main.Instance.FlashLightController.Switch();
            if (Input.GetKeyDown(_use))
            {
                if(Main.Instance.BatteryController.Battery.LookAt())
                Main.Instance.BatteryController.Taked();
            }
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                _indexWeapons = 0;
                _isSelectWeapons = false;
            }
            if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                _indexWeapons = 1;
                _isSelectWeapons = false;
            }
            if (_isSelectWeapons) return;
            if(Main.Instance.ObjectManager.GetWeaponsList[_indexWeapons])
            {
                Main.Instance.WeaponsController.On(Main.Instance.ObjectManager.GetAmmunitionList[_indexWeapons]);
            }
            _isSelectWeapons = true;

		}
	}
}
