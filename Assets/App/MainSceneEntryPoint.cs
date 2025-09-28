using Shafir.FindLogics;
using Shafir.FSM;
using Shafir.GraphViews;
using Shafir.RaycastSystem;
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
        [SerializeField] private LegendWindow legendWindow;

        private AppContext _appContext;

        private AppWorkflow _workflow;

        private void Start()
        {
            InitStates();
            InitUI();

            _workflow = new AppWorkflow(_appContext);
            _workflow.Start();
        }

        private void InitStates()
        {
            _appContext = new AppContext();
            _appContext.UserInput = userInput;
            _appContext.MainCamera = mainCamera;
            _appContext.GraphView = graphView;
            _appContext.PathDrawer = pathDrawer;
            _appContext.Raycaster = new Raycaster();
            _appContext.FindLogic = new DijkstraFindLogic();
            _appContext.AppStateMachine = new SimpleStateMachine();

            _appContext.BootState = new BootState(_appContext);
            _appContext.IdleState = new IdleState(_appContext);
            _appContext.SearchState = new SearchState(_appContext);
            _appContext.ConstructorState = new ConstructorState(_appContext);
        }

        private void InitUI()
        {
            mainWindow.Initialize();

            _appContext.MainWindow = mainWindow;
            _appContext.LoadingWindow = loadingWindow;
            _appContext.OutputWindow = outputWindow;
            _appContext.LegendWindow = legendWindow;
        }
    }
}