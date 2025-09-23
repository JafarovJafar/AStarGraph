using Shafir.FSM;

namespace Shafir.App
{
    public class DeleteEntitiesState : IState
    {
        private AppContext _appContext;

        private const string LegendText = "Удаление сущностей";

        public DeleteEntitiesState(AppContext appContext)
        {
            _appContext = appContext;
        }

        public void Enter()
        {
            _appContext.LegendWindow.Show();
            _appContext.LegendWindow.SetLegend(LegendText);
        }

        public void Exit()
        {

        }
    }
}