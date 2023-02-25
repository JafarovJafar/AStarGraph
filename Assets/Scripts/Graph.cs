using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public event Action SearchStarted;
    public event Action<float> SearchTimeUpdated;
    public event Action SearchFinished;

    [SerializeField] private List<GraphNode> _nodes;
    [SerializeField] private GraphNode _startNode;

    private Coroutine _searchCoroutine;

    public void Init()
    {
        foreach (var node in _nodes)
        {
            node.Init();
        }
    }

    public void StartSearch()
    {
        _searchCoroutine = StartCoroutine(SearchCoroutine());
    }

    private IEnumerator SearchCoroutine()
    {
        SearchStarted?.Invoke();

        float startTime = Time.unscaledTime;
        GraphNode currentNode = _startNode;
        currentNode.SetAsStartNode();

        List<GraphNode> unprocessedNodes = new List<GraphNode>(_nodes);

        while (true)
        {
            float distance;
            float newWeight;

            foreach (var neighbour in currentNode.Neighbours)
            {
                distance = Vector3.Distance(neighbour.Position, currentNode.Position);
                newWeight = distance + currentNode.Weight;
                if (neighbour.Weight < newWeight) continue;

                neighbour.UpdateWeight(currentNode, newWeight);
            }
            
            SearchTimeUpdated?.Invoke(Time.unscaledTime - startTime);

            unprocessedNodes.Remove(currentNode);

            if (unprocessedNodes.Count == 0)
            {
                break;
            }
            
            unprocessedNodes.Sort(CompareNodes);
            currentNode = unprocessedNodes[0];
            
            //if (Input.GetKeyDown(KeyCode.A)) break;

            yield return null;
        }

        SearchFinished?.Invoke();
    }

    private int CompareNodes(GraphNode first, GraphNode second)
    {
        if (second.Weight > first.Weight) return 1;
        if (first.Weight > second.Weight) return -1;
        return 0;
    }
}