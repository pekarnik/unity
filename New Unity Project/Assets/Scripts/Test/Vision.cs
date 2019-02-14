﻿using UnityEngine;

namespace Tests
{
    [System.Serializable]
    public class Vision
    {
        public float ActiveDis = 10;
        public float ActiveAng = 35;

        public bool VisionM(Transform player,Transform target)
        {
            return Dist(player, target) && Angle(player, target) && !CheckBlocked(player, target);
        }

        private bool CheckBlocked(Transform player,Transform target)
        {
            if (!Physics.Linecast(player.position, target.position, out var hit)) return true;
            return hit.transform != target;
        }

        private bool Angle(Transform player,Transform target)
        {
            var angle = Vector3.Angle(player.forward, target.position - player.position);
            return angle <= ActiveAng;
        }

        private bool Dist(Transform player,Transform target)
        {
            var dist = Vector3.Distance(player.position, target.position);
            return dist <= ActiveDis;
        }
    }
}
