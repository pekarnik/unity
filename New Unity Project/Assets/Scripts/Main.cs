﻿using UnityEngine;
using System.Collections.Generic;
namespace Game
{
	class Main:MonoBehaviour
	{
		public FlashLightController FlashLightController { get; private set; }
		public InputController InputController { get; private set; }
		public PlayerController PlayerController { get; private set; }
		public BatteryController BatteryController { get; private set; }
        public PlayerHandController PlayerHandController { get; private set; }
		private List<BaseController> _controllers = new List<BaseController>();
        [SerializeField]private Transform _handTransform;
        public Transform PlayerTransform { get; private set; }

		public static Main Instance { get; private set; }
		
        public enum MouseButton
        {
            LeftButton,
            RightButton,
            CenterButton
        }

		private void Awake()
		{
			Instance = this;
            PlayerTransform = FindObjectOfType<CharacterController>().transform;

            PlayerController = new PlayerController(new UnitMotor(PlayerTransform));
			_controllers.Add(PlayerController);
			FlashLightController = new FlashLightController();
			InputController = new InputController();
			InputController.On();
			_controllers.Add(InputController);
			FlashLightController = new FlashLightController();
			_controllers.Add(FlashLightController);
			BatteryController = new BatteryController();
			_controllers.Add(BatteryController);
            PlayerHandController = new PlayerHandController();
            _controllers.Add(PlayerHandController);
		}
        public void RemoveController(BaseController controller)
        {
            _controllers.Remove(controller);
        }
		private void Update()
		{
			for(var i=0;i<_controllers.Count;i++)
			{
				_controllers[i]?.OnUpdate();
			}
		}

	}
}
