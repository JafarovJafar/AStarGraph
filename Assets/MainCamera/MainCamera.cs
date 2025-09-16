using UnityEngine;

namespace Shafir
{
    public class MainCamera : MonoBehaviour
    {
        public Camera Camera => camera;
        
        [SerializeField] private Camera camera;
    }
}