﻿using UnityEngine;

namespace Game.Helpers
{
    public class ObjectManager:MonoBehaviour
    {
        [SerializeField]
        private Ammunition[] _ammunitionList =
            new Ammunition[5];
        [SerializeField] private Weapons[] _weaponsList = new Weapons[5];
        public Weapons[] GetWeaponsList
        {
            get { return _weaponsList; }
        }
        public Ammunition[] GetAmmunitionList
        {
            get { return _ammunitionList; }
        }
    }
}
