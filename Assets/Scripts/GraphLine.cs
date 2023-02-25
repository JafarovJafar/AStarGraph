using UnityEngine;

public class GraphLine : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;

    public bool IsActive => _gameObject.activeInHierarchy;

    private GameObject _gameObject;
    
    public void Init()
    {
        _gameObject = gameObject;
        _lineRenderer.positionCount = 2;
    }

    public void Activate() => _gameObject.SetActive(true);
    public void DeActivate() => _gameObject.SetActive(false);
    
    public void SetPoints(Vector3 startPosition, Vector3 endPosition)
    {
        _lineRenderer.SetPosition(0, startPosition);
        _lineRenderer.SetPosition(1, endPosition);
    }
}