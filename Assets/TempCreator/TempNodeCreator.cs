using UnityEngine;

namespace TempCreator
{
    internal class TempNodeCreator : MonoBehaviour
    {
        public ulong Id;
        public Vector3 Position => transform.position;
    }
}