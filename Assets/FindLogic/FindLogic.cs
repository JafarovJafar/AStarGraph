using System;

namespace Shafir.FindLogics
{
    /// <summary>
    /// Базовый класс поиска путей
    /// </summary>
    public abstract class FindLogic
    {
        /// <summary>
        /// Результат последнего поиска
        /// </summary>
        public FindOutput Output { get; private set; }

        public FindLogic()
        {
            Output = new FindOutput();
        }

        public abstract void Find(Graph graph, ulong startNodeId, ulong endNodeId, Action<FindOutput> finished);
    }
}