using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField] private PathDrawer _pathDrawer;
    [SerializeField] private List<GraphNode> _nodes;

    public List<GraphNode> Nodes => _nodes;

    private Coroutine _searchCoroutine;

    public void Init()
    {
        foreach (var node in _nodes) node.Init();
        foreach (var node in _nodes) node.DrawLines();
    }
}