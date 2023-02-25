using UnityEngine;

public class SceneController
{
    public SceneController(
        Graph graph,
        PathSearcher pathSearcher,
        PathDrawer pathDrawer,
        GameUI gameUI)
    {
        _graph = graph;
        _pathSearcher = pathSearcher;
        _pathDrawer = pathDrawer;
        _gameUI = gameUI;

        _gameUI.StartSearchClicked += StartSearch_Clicked;
        
        _pathDrawer.Clear();

        _pathSearcher.SearchFinished += DrawPath;
    }

    private Graph _graph;

    private PathDrawer _pathDrawer;
    private PathSearcher _pathSearcher;
    private GameUI _gameUI;

    private GraphNode _startNode;
    private GraphNode _goalNode;

    public void SetNodes(GraphNode startNode, GraphNode goalNode)
    {
        _startNode = startNode;
        _goalNode = goalNode;
    }

    private void StartSearch_Clicked()
    {
        // пока что рандомно выбирает точки
        // в будущем надо добавить выбор вершины по клику
        _startNode = _graph.Nodes[0];
        _goalNode = _graph.Nodes[Random.Range(1, _graph.Nodes.Count - 1)];

        _pathDrawer.Clear();
        _pathSearcher.StartSearch(_startNode, _goalNode);
    }

    private void DrawPath() => _pathDrawer.Draw(_pathSearcher.LastFoundPath);
}