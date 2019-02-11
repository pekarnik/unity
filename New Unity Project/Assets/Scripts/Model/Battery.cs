using UnityEngine;

namespace Game
{
	public class Battery:PickableObject
	{

        public override void TakeObject()
        {
            base.TakeObject();
            Main.Instance.FlashLightController.Recharged();
            
        }
    }
}
