using Shafir.FSM;

namespace Shafir.App
{
    /// <summary>
    /// Поиск пути завершен
    /// </summary>
    public class PathSearchFinishedState : IState
    {
        private AppContext _appContext;

        public PathSearchFinishedState(AppContext appContext)
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