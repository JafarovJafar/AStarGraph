using UnityEngine;

public class MainSceneEntryPoint : MonoBehaviour
{
    private void Start()
    {
        _graph.Init();
        _gameUI.Init(_graph);

        _sceneController = new SceneController(_graph, _gameUI);
    }

    [SerializeField] private Graph _graph;
    [SerializeField] private GameUI _gameUI;

    private SceneController _sceneController;
}