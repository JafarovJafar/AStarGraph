using System.Collections.Generic;
using UnityEngine;

public class GraphNode : MonoBehaviour
{
    [SerializeField] private List<GraphNode> _neighbours;

    public void Init()
    {
        
    }

    private void OnDrawGizmos()
    {
        foreach (var neighbour in _neighbours)
        {
            Gizmos.DrawLine(transform.position, neighbour.transform.position);
        }
    }
}