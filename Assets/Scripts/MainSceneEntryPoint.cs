using UnityEngine;

public class MainSceneEntryPoint : MonoBehaviour
{
    private void Start()
    {
        _linesPool.Init();
        
        _graph.Init();
        _pathSearcher.Init(_graph);
        _gameUI.Init(_pathSearcher);

        _sceneController = new SceneController(_graph, _pathSearcher, _pathDrawer, _gameUI);
    }

    [SerializeField] private LinesPool _linesPool;
    [SerializeField] private Graph _graph;
    [SerializeField] private PathSearcher _pathSearcher;
    [SerializeField] private PathDrawer _pathDrawer;
    [SerializeField] private GameUI _gameUI;

    private SceneController _sceneController;
}