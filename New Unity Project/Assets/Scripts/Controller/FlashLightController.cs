using UnityEngine;

namespace Game
{
	class FlashLightController:BaseController
	{
		private FlashLight _flashlight;
		public override void OnUpdate()
		{
			if (!IsActive) return;
			if (_flashlight == null) return;
			_flashlight.Rotation();
			if (_flashlight.EditBatteryCharge())
			{
				UIInterface.LightUIText.Text = _flashlight.BatteryChargeCurrent;
			}
			else
			{
				Off();
			}
		}
		public override void On()
		{
			if (IsActive) return;
			base.On();
            _flashlight = Main.Instance.ObjectManager.FlashLight;
            _flashlight.Switch(true);
            UIInterface.LightUIText.SetActive(true);
		}
		public sealed override void Off()
		{
			if (!IsActive) return;
			base.Off();
			_flashlight.Switch(false);
            UIInterface.LightUIText.SetActive(false);
		}
		public void Recharged()
		{
			_flashlight.ChargeBattery();
		}
	}
}
