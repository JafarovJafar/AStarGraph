using Shafir.FindLogics;
using Shafir.FSM;
using Shafir.GraphViews;
using Shafir.UI;
using UnityEngine;

namespace Shafir.App
{
    public class MainSceneEntryPoint : MonoBehaviour
    {
        [SerializeField] private GraphView graphView;
        [SerializeField] private MainWindow mainWindow;
        [SerializeField] private LoadingWindow loadingWindow;

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
            _appContext.GraphView = graphView;
            _appContext.FindLogic = new DijkstraFindLogic();
            _appContext.AppStateMachine = new SimpleStateMachine();

            _bootState = new(_appContext);
            _waitingUserActionState = new(_appContext);
            _searchingPathState = new(_appContext);
            _pathSearchFinishedState = new(_appContext);

            _appContext.BootState = _bootState;
            _appContext.WaitingUserActionState = _waitingUserActionState;
            _appContext.SearchingPathState = _searchingPathState;
            _appContext.PathSearchFinishedState = _pathSearchFinishedState;
        }

        private void InitUI()
        {
            mainWindow.Initialize();

            _appContext.MainWindow = mainWindow;
            _appContext.LoadingWindow = loadingWindow;
        }
    }
}