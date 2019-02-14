﻿using UnityEngine;

namespace Game
{
    public struct InfoCollision
    {
        private readonly Vector3 _dir;
        private readonly float _damage;
        private readonly ContactPoint _contact;
        private readonly Transform _objCollision;

        public InfoCollision(float damage, ContactPoint contact,Transform objCollision, Vector3 dir = default(Vector3))
        {
            _damage = damage;
            _dir = dir;
            _contact = contact;
            _objCollision = objCollision;
        }

        public Vector3 Dir => _dir;

        public float Damage => _damage;

        public ContactPoint Contact => _contact;

        public Transform ObjCollision => _objCollision;
    }
}
