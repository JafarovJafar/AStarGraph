using Shafir.GraphViews;
using UnityEngine;

namespace TempCreator
{
    internal class TempGraphCreator : MonoBehaviour
    {
        [SerializeField] private GraphView graphView;

        public void Start()
        {
            var edges = FindObjectsByType<TempEdgeCreator>(FindObjectsSortMode.None);

            var graphModel = new GraphModel();

            foreach (var edge in edges)
            {
                var startNode = edge.Start;
                var endNode = edge.End;

                graphModel.AddEdge
                (
                    edge.Id, edge.Length,
                    startNode.Id, startNode.Position,
                    endNode.Id, endNode.Position
                );
            }

            graphView.SetModel(graphModel);

            gameObject.SetActive(false);
        }
    }
}