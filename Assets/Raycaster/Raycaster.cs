using UnityEngine;

namespace Shafir.RaycastSystem
{
    public class Raycaster
    {
        public bool TryRaycast<T>(Camera camera, Vector2 mousePosition, LayerMask layerMask, out T foundComponent)
        {
            var ray = camera.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, float.MaxValue, layerMask) == true)
            {
                return TryGetComponent(hitInfo, out foundComponent);
            }

            foundComponent = default;
            return false;
        }

        public bool TryRaycast<T>(Camera camera, Vector2 mousePosition, out T foundComponent)
        {
            var ray = camera.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, float.MaxValue) == true)
            {
                return TryGetComponent(hitInfo, out foundComponent);
            }

            foundComponent = default;
            return false;
        }

        private bool TryGetComponent<T>(RaycastHit hitInfo, out T foundComponent)
        {
            if (hitInfo.transform.TryGetComponent(out foundComponent) == true)
            {
                return true;
            }

            if (hitInfo.transform.TryGetComponent(out RaycastRetargeter retargeter) == true)
            {
                if (retargeter.TryGetComponent(out foundComponent) == true)
                {
                    return true;
                }
            }

            foundComponent = default;
            return false;
        }
    }
}