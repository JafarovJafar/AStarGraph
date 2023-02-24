using System;
using System.Collections;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public event Action SearchStarted;
    public event Action<float> SearchTimeUpdated;
    public event Action SearchFinished;

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