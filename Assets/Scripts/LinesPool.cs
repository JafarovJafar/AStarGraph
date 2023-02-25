using System.Collections.Generic;
using UnityEngine;

public class LinesPool : MonoBehaviour
{
    [SerializeField] private GraphLine _prefab;

    public static LinesPool Instance => _instance;

    private static LinesPool _instance;

    private List<GraphLine> _lines = new();

    private Transform _transform;

    public void Init()
    {
        _transform = transform;

        _instance = this;
    }

    public GraphLine Get()
    {
        GraphLine line = _lines.Find(x => !x.IsActive);

        if (line == null)
        {
            line = Instantiate(_prefab, _transform);
            line.Init();
            _lines.Add(line);
        }

        line.Activate();
        return line;
    }
}