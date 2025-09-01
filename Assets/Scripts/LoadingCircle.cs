using UnityEngine;

public class LoadingCircle : MonoBehaviour
{
    [SerializeField] private Transform _spriteTransform;
    [SerializeField] private float _rotateSpeed = 225f;

    private GameObject _gameObject;

    public void Init()
    {
        _gameObject = gameObject;
    }

    public void Show()
    {
        _spriteTransform.localEulerAngles = Vector3.zero;
        _gameObject.SetActive(true);
    }

    public void Hide()
    {
        _gameObject.SetActive(false);
    }

    private void Update()
    {
        _spriteTransform.Rotate(Vector3.back, _rotateSpeed * Time.deltaTime);
    }
}