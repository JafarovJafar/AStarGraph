using Shafir.FSM;

namespace Shafir.App
{
    public class CreateEdgesState : IState
    {
        private AppContext _appContext;

        private const string LegendText = "Добавление ребер";

        public CreateEdgesState(AppContext appContext)
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