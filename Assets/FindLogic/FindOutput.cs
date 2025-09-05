using System.Collections.Generic;

namespace Shafir.FindLogics
{
    /// <summary>
    /// Результат вычисления пути
    /// </summary>
    public class FindOutput
    {
        public bool IsSuccess { get; private set; }
        public bool IsFinished { get; private set; }
        public float FindDuration { get; private set; }
        public IReadOnlyList<ulong> FoundPath => _foundPath;

        private List<ulong> _foundPath = new();

        internal void SetNodes(IEnumerable<ulong> nodes)
        {
            _foundPath.AddRange(nodes);
        }

        internal void SetSuccess(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        internal void SetDuration(float duration)
        {
            FindDuration = duration;
        }

        internal void Clear()
        {
            _foundPath.Clear();
        }
    }
}