using UnityEngine;

namespace Game
{
	public class Battery:PickableObject
	{

        public override void TakeObject()
        {
            
            Main.Instance.FlashLightController.Recharged();
            base.TakeObject();
        }
    }
}
