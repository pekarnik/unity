using UnityEngine;

namespace Game
{
	public class PlayerController:BaseController
	{
		private IMotor _motor;
        public PlayerHand PlayerHand { get; private set; }

		public PlayerController(IMotor motor)
		{
			_motor = motor;            
		}
		public override void OnUpdate()
		{
			_motor.Move();
		}
        
	}
}
