using Shafir.FSM;
using Shafir.UI;

namespace Shafir.App
{
    public class CreateNodesState : IState
    {
        private AppContext _appContext;

        private Window _openedWindow;

        private const string LegendText = "Добавление вершин";

        public CreateNodesState(AppContext appContext)
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
            _appContext.LegendWindow.Hide();
        }
    }
}