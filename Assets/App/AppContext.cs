using Shafir.FindLogics;
using Shafir.FSM;
using Shafir.GraphViews;
using Shafir.UI;

namespace Shafir.App
{
    public class AppContext
    {
        public SimpleStateMachine AppStateMachine;

        public WaitingUserActionState WaitingUserActionState;
        public SearchingPathState SearchingPathState;
        public PathSearchFinishedState PathSearchFinishedState;

        public GraphView GraphView;
        public PathDrawer PathDrawer;

        public FindLogic FindLogic;

        public MainWindow MainWindow;
        public LoadingWindow LoadingWindow;
        public OutputWindow OutputWindow;
    }
}