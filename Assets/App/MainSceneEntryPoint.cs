using Shafir.FindLogics;
using Shafir.FSM;
using Shafir.GraphViews;
using Shafir.UI;
using UnityEngine;

namespace Shafir.App
{
    public class MainSceneEntryPoint : MonoBehaviour
    {
        [SerializeField] private UserInput userInput;
        [SerializeField] private MainCamera mainCamera;
        [SerializeField] private GraphView graphView;
        [SerializeField] private PathDrawer pathDrawer;
        [SerializeField] private MainWindow mainWindow;
        [SerializeField] private LoadingWindow loadingWindow;
        [SerializeField] private OutputWindow outputWindow;

        private BootState _bootState;
        private WaitingUserActionState _waitingUserActionState;
        private SearchingPathState _searchingPathState;
        private PathSearchFinishedState _pathSearchFinishedState;
        private AppContext _appContext;

        private void Start()
        {
            InitStates();
            InitUI();

            _appContext.AppStateMachine.ChangeState(_bootState);
        }

        private void InitStates()
        {
            _appContext = new AppContext();
            _appContext.UserInput = userInput;
            _appContext.MainCamera = mainCamera;
            _appContext.GraphView = graphView;
            _appContext.PathDrawer = pathDrawer;
            _appContext.FindLogic = new DijkstraFindLogic();
            _appContext.AppStateMachine = new SimpleStateMachine();

            _bootState = new(_appContext);
            _waitingUserActionState = new(_appContext);
            _searchingPathState = new(_appContext);
            _pathSearchFinishedState = new(_appContext);

            _appContext.WaitingUserActionState = _waitingUserActionState;
            _appContext.SearchingPathState = _searchingPathState;
            _appContext.PathSearchFinishedState = _pathSearchFinishedState;
        }

        private void InitUI()
        {
            mainWindow.Initialize();

            _appContext.MainWindow = mainWindow;
            _appContext.LoadingWindow = loadingWindow;
            _appContext.OutputWindow = outputWindow;

            _appContext.OutputWindow.Show();
        }
    }
}