using Shafir.FSM;

namespace Shafir.App
{
    public class CreateEdgesState : IState
    {
        private AppContext _appContext;

        public CreateEdgesState(AppContext appContext)
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