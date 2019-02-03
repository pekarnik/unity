using UnityEngine;

namespace Game
{
	public class Battery:PickableObject
	{
		public override void Picked()
		{
			base.Picked();
			Main.Instance.FlashLightController.Recharged();
		}
	}
}
