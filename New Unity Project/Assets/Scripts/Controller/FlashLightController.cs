using UnityEngine;

namespace Game
{
	class FlashLightController:BaseController
	{
		private FlashLight _flashlight;
		private FlashLightUIText _flashLightUIText;
		public FlashLightController()
		{
			_flashlight = MonoBehaviour.FindObjectOfType<FlashLight>();
			_flashLightUIText = MonoBehaviour.FindObjectOfType<FlashLightUIText>();
			Off();
		}
		public override void OnUpdate()
		{
			if (!IsActive) return;
			if (_flashlight == null) return;
			_flashlight.Rotation();
			if (_flashlight.EditBatteryCharge())
			{
				_flashLightUIText.Text = _flashlight.BatteryChargeCurrent;
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
			_flashlight.Switch(true);

			_flashLightUIText.SetActive(true);
		}
		public sealed override void Off()
		{
			if (!IsActive) return;
			base.Off();
			_flashlight.Switch(false);
			_flashLightUIText.SetActive(false);
		}
		public void Recharged()
		{
			_flashlight.ChargeBattery();
		}
	}
}
