using TMPro;
using UnityEngine;

public class TimeText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private PathSearcher _pathSearcher;

    public void Init(PathSearcher pathSearcher)
    {
        _pathSearcher = pathSearcher;
        _pathSearcher.SearchTimeUpdated += UpdateTime;
    }

    private void UpdateTime(float time)
    {
        _text.text = $"Elapsed time: {time}";
    }
}