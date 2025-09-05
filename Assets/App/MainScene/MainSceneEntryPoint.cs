using System.Collections.Generic;
using Shafir.FindLogics;
using Shafir.GraphViews;
using Shafir.UI;
using UnityEngine;

namespace Shafir.App
{
    public class MainSceneEntryPoint : MonoBehaviour
    {
        [SerializeField] private GraphView graphView;

        [SerializeField] private MainWindow mainWindow;
        [SerializeField] private LoadingWindow loadingWindow;

        [SerializeField] private LineRenderer pathLineRenderer;

        private DijkstraFindLogic _dijkstraFindLogic;

        private void Start()
        {
            _dijkstraFindLogic = new DijkstraFindLogic();

            mainWindow.Initialize();
            mainWindow.Show();
            mainWindow.StartClicked += OnStartClicked;
        }

        private void OnStartClicked()
        {
            mainWindow.Hide();
            loadingWindow.Show();

            var searchModel = GetFindGraph(graphView.Model);
            _dijkstraFindLogic.Find(searchModel, 0, 3, output =>
            {
                mainWindow.Show();
                mainWindow.SetTime(output.FindDuration);
                loadingWindow.Hide();

                var points = output.FoundPath;

                var linePoints = new List<Vector3>();

                for (int idx = 0; idx < points.Count - 1; idx++)
                {
                    var firstNode = graphView.Model.Nodes[points[idx]];
                    linePoints.Add(firstNode.Position);
                }

                linePoints.Add(graphView.Model.Nodes[points[^1]].Position);

                pathLineRenderer.positionCount = points.Count;
                pathLineRenderer.SetPositions(linePoints.ToArray());
            });
        }

        private Graph GetFindGraph(GraphModel model)
        {
            var result = new Graph();

            foreach (var edge in model.Edges.Values)
            {
                result.AddEdge(edge.Id, edge.StartNode.Id, edge.EndNode.Id, edge.Cost);
            }

            return result;
        }
    }
}