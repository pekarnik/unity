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
            if (Input.GetKeyDown(_use))
            {
                if(Main.Instance.BatteryController.Battery.LookAt())
                Main.Instance.BatteryController.Taked();
            }

		}
	}
}
