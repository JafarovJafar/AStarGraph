using System.Collections.Generic;
using UnityEngine;

public class GraphNode : MonoBehaviour
{
    [SerializeField] private List<GraphNode> _neighbours;

    [field:SerializeField] public GraphNode LastNode { get; private set; }
    [field:SerializeField]public float Weight { get; private set; }

    public List<GraphNode> Neighbours => _neighbours;
    public Vector3 Position => _transform.position;

    private Transform _transform;
    
    public void Init()
    {
        _transform = transform;
        Weight = float.PositiveInfinity;
    }

    public void DrawLines()
    {
        foreach (var neighbour in _neighbours)
        {
            GraphLine line = LinesPool.Instance.Get();
            line.SetPoints(Position, neighbour.Position);
        }
    }

    public void SetAsStartNode() => Weight = 0f;
    
    public void UpdateWeight(GraphNode node, float weight)
    {
        LastNode = node;
        Weight = weight;
    }

    private void OnDrawGizmos()
    {
        foreach (var neighbour in _neighbours)
        {
            Gizmos.DrawLine(transform.position, neighbour.transform.position);
        }
    }

    public void ResetSearchVars()
    {
        LastNode = null;
        Weight = float.PositiveInfinity;
    }
}