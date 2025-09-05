using UnityEngine;

namespace Shafir.UI
{
    public class LoadingCircle : MonoBehaviour
    {
        [SerializeField] private Transform _spriteTransform;
        [SerializeField] private float _rotateSpeed = 225f;

        public void Show()
        {
            _spriteTransform.localEulerAngles = Vector3.zero;
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void Update()
        {
            _spriteTransform.Rotate(Vector3.back, _rotateSpeed * Time.deltaTime);
        }
    }
}