using UnityEngine;

namespace Shafir.RaycastSystem
{
    internal class RaycastRetargeter : MonoBehaviour
    {
        public GameObject Target => target;

        [SerializeField] private GameObject target;
    }
}