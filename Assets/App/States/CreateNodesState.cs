using Shafir.FSM;

namespace Shafir.App
{
    public class CreateNodesState : IState
    {
        private AppContext _appContext;

        public CreateNodesState(AppContext appContext)
        {
            _appContext = appContext;
        }

        public void Enter()
        {

        }

        public void Exit()
        {

        }
    }
}