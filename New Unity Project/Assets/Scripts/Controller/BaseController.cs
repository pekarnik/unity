using UnityEngine;

namespace Game
{
	public abstract class BaseController
	{
        protected UIInterface UIInterface;

        protected BaseController()
        {
            UIInterface = new UIInterface();
        }

		public bool IsActive { get; private set; }
		public virtual void On()
		{
			On(null);
		}
		public virtual void On(BaseObjectScene obj)
		{
			IsActive = true;
		}
		public virtual void Off()
		{
			IsActive = false;
		}
		public void Switch()
		{
			if(IsActive)
			{
				Off();
			}
			else
			{
				On();
			}
		}
		public abstract void OnUpdate();
	}
}
