using UnityEngine;

namespace Game
{ 
	public class InputController:BaseController
	{
		private KeyCode _codeFlashLight = KeyCode.F;
		private KeyCode _use = KeyCode.E;
		public override void OnUpdate()
		{
			if (!IsActive) return;
			if(Input.GetKeyDown(_codeFlashLight))
				Main.Instance.FlashLightController.Switch();
			if(Input.GetKeyDown(_use)&& Main.Instance.BatteryController.Battery.IsSelected)
			{
				Main.Instance.BatteryController.Picked();
			}
		}
	}
}
