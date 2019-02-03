using UnityEngine;
using System.Collections.Generic;
namespace Game
{
	class Main:MonoBehaviour
	{
		public FlashLightController FlashLightController { get; private set; }
		public InputController InputController { get; private set; }
		public PlayerController PlayerController { get; private set; }
		public BatteryController BatteryController { get; private set; }
		private List<BaseController> _controllers = new List<BaseController>();
		private List<PickableController> _pickableControllers = new List<PickableController>(); 

		public static Main Instance { get; private set; }
		

		private void Awake()
		{
			Instance = this;
			PlayerController=new PlayerController(new UnitMotor(
				FindObjectOfType<CharacterController>().transform));
			_controllers.Add(PlayerController);
			FlashLightController = new FlashLightController();
			InputController = new InputController();
			InputController.On();
			_controllers.Add(InputController);

			FlashLightController = new FlashLightController();
			_controllers.Add(FlashLightController);
			BatteryController = new BatteryController();
			_pickableControllers.Add(BatteryController);
			
		}

		private void Update()
		{
			foreach(var controller in _controllers)
			{
				controller.OnUpdate();
			}
			//foreach(var pickable in _pickableControllers)
			//{
			//	//pickable.OnUpdate();
			//}
		}
	}
}
