using System;

namespace Shafir.FindLogics
{
    /// <summary>
    /// Базовый класс поиска путей
    /// </summary>
    public abstract class FindLogic
    {
        public FindOutput Output { get; private set; }

        public FindLogic()
        {
            Output = new FindOutput();
        }

        public abstract void Find(Graph graph, Action<FindOutput> finished);
    }
}