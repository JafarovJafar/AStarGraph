using System;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public event Action StartSearchClicked;

    [SerializeField] private Button _searchButton;
    [SerializeField] private TimeText _timeText;
    [SerializeField] private LoadingCircle _loadingCircle;
    [SerializeField] private GameObject _inputBlocker;

    private Graph _graph;

    public void Init(Graph graph)
    {
        _graph = graph;
        _graph.SearchStarted += Graph_SearchStarted;
        _graph.SearchFinished += Graph_SearchFinished;

        _searchButton.onClick.AddListener(SearchButton_Clicked);
        _timeText.Init(_graph);
        _loadingCircle.Init();
        _loadingCircle.Hide();
        _inputBlocker.SetActive(false);
    }

    private void SearchButton_Clicked() => StartSearchClicked?.Invoke();

    private void Graph_SearchStarted()
    {
        _inputBlocker.SetActive(true);
        _loadingCircle.Show();
    }

    private void Graph_SearchFinished()
    {
        _inputBlocker.SetActive(false);
        _loadingCircle.Hide();
    }
}