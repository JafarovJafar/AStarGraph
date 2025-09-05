using UnityEngine;

namespace TempCreator
{
    internal class TempEdgeCreator : MonoBehaviour
    {
        public ulong Id;
        public TempNodeCreator Start;
        public TempNodeCreator End;
        public float Length => Vector3.Distance(Start.Position, End.Position);

        public Color GizmosColor;

        private void OnDrawGizmos()
        {
            if (Start == null) return;
            if (End == null) return;

            Gizmos.color = GizmosColor;
            Gizmos.DrawLine(Start.Position, End.Position);
        }
    }
}