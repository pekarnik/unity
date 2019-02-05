using UnityEngine;

namespace Game
{
	public class BatteryController:PickableController
	{
		public Battery Battery { get; private set; }

		public void Picked()
		{
			Battery.Picked();
		}
	}
}
