using Shafir.FSM;

namespace Shafir.App
{
    /// <summary>
    /// Поиск пути
    /// </summary>
    public class SearchingPathState : IState
    {
        private AppContext _appContext;

        public SearchingPathState(AppContext appContext)
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