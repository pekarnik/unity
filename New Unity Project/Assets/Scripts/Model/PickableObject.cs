using UnityEngine;

namespace Game
{
	public abstract class PickableObject:BaseObjectScene
	{
		public GameObject IsSelected { get; private set; }
		public PickableObject()
		{
			IsSelected = null;
		}
		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.tag == "Player")
			{
				gameObject.GetComponent<MeshRenderer>().sharedMaterial.color = Color.green;
				IsSelected = gameObject;
			}
		}
		protected void OnTriggerExit(Collider other)
		{
			gameObject.GetComponent<MeshRenderer>().sharedMaterial.color = Color.red;
			IsSelected = null;
		}
		public virtual void Picked()
		{
			Destroy(IsSelected);
		}
	}
}

