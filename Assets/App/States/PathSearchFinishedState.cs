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
            var duration = _appContext.FindLogic.Output.FindDuration;
            _appContext.OutputWindow.SetTime(duration);
            _appContext.AppStateMachine.ChangeState(_appContext.WaitingUserActionState);
        }

        public void Exit()
        {

        }
    }
}