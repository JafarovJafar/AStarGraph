using TMPro;
using UnityEngine;

public class TimeText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    
    private Graph _graph;
    
    public void Init(Graph graph)
    {
        _graph = graph;
        _graph.SearchTimeUpdated += UpdateTime;
    }

    private void UpdateTime(float time)
    {
        _text.text = $"Elapsed time: {time}";
    }
}