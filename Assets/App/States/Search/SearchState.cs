using Shafir.FSM;

namespace Shafir.App
{
    public class SearchState : IState
    {
        private readonly AppContext _appContext;

        public SearchState(AppContext appContext)
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