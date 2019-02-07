using UnityEngine;

namespace Game
{
	public abstract class PickableObject:BaseObjectScene
	{
        private float distanceToPick = 1.5f;
		public virtual void TakeObject()
        {
            Destroy(gameObject);            
        }        
        public void ColorChangeLookAt()
        {
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            if(meshRenderer)
            {
                meshRenderer.material.color = Color.green;
            }
        }
        public void ColorChangeDontLookAt()
        {
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            if (meshRenderer)
            {
                meshRenderer.material.color = Color.red;
            }
        }
        public bool LookAt()
        {
            if (Main.Instance.PlayerHandController.
                PlayerHand.GetRaycastHit().transform?.GetComponent<PickableObject>() && Vector3.Distance(gameObject.transform.position,
                Main.Instance.PlayerTransform.position)<distanceToPick)
            {

                ColorChangeLookAt();
                return true;
            }
                ColorChangeDontLookAt();
            return false;
        }
	}
}


