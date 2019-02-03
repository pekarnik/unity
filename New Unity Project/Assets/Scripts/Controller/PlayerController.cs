using UnityEngine;

namespace Game
{
	public class PlayerController:BaseController
	{
		private IMotor _motor;

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
