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

        public FindOutput()
        {
            IsSuccess = false;
        }
    }
}