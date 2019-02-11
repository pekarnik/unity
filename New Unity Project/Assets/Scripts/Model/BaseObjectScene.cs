using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{	
	public abstract class BaseObjectScene : MonoBehaviour
	{
		private int _layer;
        private Color _color;
		public Transform Transform { get; private set; }
        private bool _isVisible;
        [HideInInspector] public Rigidbody Rigidbody;

        protected virtual void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            Transform = transform;
        }

        public string Name
        {
            get => gameObject.name;
            set => gameObject.name = value;
        }
		public int Layer
        {
            get
            {
                return _layer;
            }

            set
            {
                _layer = value;
                AskLayer(Transform, _layer);
            }
        }
        public Color Color
        {
            get => _color;
            set
            {
                _color = value;
                AskColor(transform, _color);
            }
        }
        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                _isVisible = value;
                var tempRenderer = GetComponent<Renderer>();
                if (tempRenderer)
                    tempRenderer.enabled = _isVisible;
                if (transform.childCount <= 0) return;
                foreach(Transform d in transform)
                {
                    tempRenderer = d.gameObject.GetComponent<Renderer>();
                    if (tempRenderer)
                        tempRenderer.enabled = _isVisible;
                }
            }
        }

        private void AskLayer(Transform obj,int layer)
		{
			obj.gameObject.layer = layer;
			if(obj.childCount <= 0)
			{
				return;
			}
			foreach(Transform child in obj)
			{
				AskLayer(child, layer);
			}
		}
        private void AskColor(Transform obj, Color color)
        {
            foreach(var curMaterial in obj.GetComponent<Renderer>().materials)
            {
                curMaterial.color = color;
            }
            if (obj.childCount <= 0) return;
            foreach(Transform d in obj)
            {
                AskColor(d, color);
            }
        }

        public bool IsRigidBody() => Rigidbody;

        public void DisableRigidBody()
        {
            if (!IsRigidBody()) return;

            var rigidbodies = GetComponentsInChildren<Rigidbody>();
            foreach(var rb in rigidbodies)
            {
                rb.isKinematic = true;
            }
        }

        public void EnableRigidBody(float force)
        {
            EnableRigidBody();
            Rigidbody.AddForce(transform.forward * force);
        }

        public void EnableRigidBody()
        {
            if (!IsRigidBody()) return;
            var rigidbodies = GetComponentsInChildren<Rigidbody>();
            foreach(var rb in rigidbodies)
            {
                rb.isKinematic = false;
            }
        }

        public void ConstraintsRigidBody(RigidbodyConstraints rigidbodyConstraints)
        {
            var rigidbodies = GetComponentsInChildren<Rigidbody>();
            foreach(var rb in rigidbodies)
            {
                rb.constraints = rigidbodyConstraints;
            }
        }

        public void SetActive(bool value)
        {
            IsVisible = value;

            var tempCollider = GetComponent<Collider>();
            if(tempCollider)
            {
                tempCollider.enabled = value;
            }
        }
	
	}
}