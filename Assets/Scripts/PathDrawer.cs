using UnityEngine;

public class PathDrawer : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;

    public void Clear()
    {
        _lineRenderer.positionCount = 0;
    }

    public void Draw(GraphPath path)
    {
        _lineRenderer.positionCount = path.Nodes.Count;
        
        for (int i = 0; i < path.Nodes.Count; i++)
        {
            _lineRenderer.SetPosition(i, path.Nodes[i].Position);
        }
    }
}