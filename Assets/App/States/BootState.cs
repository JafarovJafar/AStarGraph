using System;
using Shafir.FSM;

namespace Shafir.App
{
    /// <summary>
    /// Инициализация приложения
    /// </summary>
    public class BootState : IState
    {
        public event Action Finished;
        
        private AppContext _appContext;

        public BootState(AppContext appContext)
        {
            _appContext = appContext;
        }

        public void Enter()
        {
            Finished?.Invoke();
        }

        public void Exit()
        {

        }
    }
}