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

    }

    public void StartSearch()
    {
        _searchCoroutine = StartCoroutine(SearchCoroutine());
    }

    private IEnumerator SearchCoroutine()
    {
        SearchStarted?.Invoke();

        //

        SearchFinished?.Invoke();
        yield break;
    }
}