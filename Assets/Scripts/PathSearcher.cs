using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSearcher : MonoBehaviour
{
    public event Action SearchStarted;
    public event Action<float> SearchTimeUpdated;
    public event Action SearchFinished;
    
    public GraphPath LastFoundPath { get; private set; }
    
    private Graph _graph;

    private Coroutine _searchCoroutine;
    
    public void Init(Graph graph)
    {
        _graph = graph;
    }
    
    public void StartSearch(GraphNode startNode, GraphNode goalNode)
    {
        foreach (var node in _graph.Nodes)
        {
            node.ResetSearchVars();
        }
        
        _searchCoroutine = StartCoroutine(SearchCoroutine(startNode, goalNode));
    }

    private IEnumerator SearchCoroutine(GraphNode startNode, GraphNode goalNode)
    {
        SearchStarted?.Invoke();

        if (goalNode == startNode)
        {
            LastFoundPath = new();
            SearchTimeUpdated?.Invoke(0);
            SearchFinished?.Invoke();
            yield break;
        }
        
        float startTime = Time.unscaledTime;
        GraphNode currentNode = startNode;
        currentNode.SetAsStartNode();

        List<GraphNode> unprocessedNodes = new List<GraphNode>(_graph.Nodes);

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

            yield return null;
        }

        LastFoundPath = new GraphPath();
        currentNode = goalNode;
        LastFoundPath.AddNode(currentNode);

        while (true)
        {
            LastFoundPath.AddNode(currentNode.LastNode);

            if (currentNode.LastNode == startNode)
            {
                break;
            }

            currentNode = currentNode.LastNode;

            SearchTimeUpdated?.Invoke(Time.unscaledTime - startTime);

            yield return null;
        }

        SearchTimeUpdated?.Invoke(Time.unscaledTime - startTime);
        SearchFinished?.Invoke();
    }

    private int CompareNodes(GraphNode first, GraphNode second)
    {
        if (second.Weight > first.Weight) return 1;
        if (first.Weight > second.Weight) return -1;
        return 0;
    }
}