public class SceneController
{
    public SceneController(Graph graph, GameUI gameUI)
    {
        _graph = graph;
        _gameUI = gameUI;
        
        _gameUI.StartSearchClicked += _graph.StartSearch;
    }

    private Graph _graph;
    private GameUI _gameUI;
}