﻿using UnityEngine;

namespace Game
{
	public class BatteryController:BaseController
	{
		public Battery Battery { get; private set; }

        public BatteryController()
        {
            Battery = MonoBehaviour.FindObjectOfType<Battery>();
        }
        public override void OnUpdate()
        {
            Battery.LookAt();
        }
        public void Taked()
        {
            if (Main.Instance.BatteryController.Battery.LookAt())
            {
                Main.Instance.BatteryController.Battery.TakeObject();
                Main.Instance.RemoveController(this);
            }
        }
    }
}
