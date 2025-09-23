using Shafir.FindLogics;
using Shafir.FSM;
using Shafir.GraphViews;
using Shafir.UI;

namespace Shafir.App
{
    public class AppContext
    {
        public SimpleStateMachine AppStateMachine;

        public BootState BootState;
        public IdleState IdleState;
        public SearchState SearchState;
        public ConstructorState ConstructorState;

        public UserInput UserInput;
        public MainCamera MainCamera;
        public GraphView GraphView;
        public PathDrawer PathDrawer;

        public FindLogic FindLogic;

        public MainWindow MainWindow;
        public LoadingWindow LoadingWindow;
        public OutputWindow OutputWindow;
        public LegendWindow LegendWindow;
    }
}