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

    private PathSearcher _pathSearcher;

    public void Init(PathSearcher pathSearcher)
    {
        _pathSearcher = pathSearcher;
        _pathSearcher.SearchStarted += Graph_SearchStarted;
        _pathSearcher.SearchFinished += Graph_SearchFinished;

        _searchButton.onClick.AddListener(SearchButton_Clicked);
        _timeText.Init(_pathSearcher);
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