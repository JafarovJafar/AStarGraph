using System;
using System.Collections.Generic;
using UnityEngine;

namespace Shafir.FindLogics
{
    /// <summary>
    /// Алгоритм Дейкстры
    /// </summary>
    public class DijkstraFindLogic : FindLogic
    {
        private LinkedList<ulong> _nodesToProcess = new();

        private int _counter;

        public override void Find(Graph graph, ulong startNodeId, ulong endNodeId, Action<FindOutput> finished)
        {
            var nodes = graph.Nodes;
            var output = new FindOutput()

            // подготовка графа к поиску
            Prepare(nodes, startNodeId, _nodesToProcess);

            // поиск пути
            CalculatePath(nodes, endNodeId, _nodesToProcess);

            // собираем найденный путь
            var foundPath = CollectPath(nodes, startNodeId, endNodeId);
            
        }

        private void Prepare
        (
            IReadOnlyDictionary<ulong, Node> nodes,
            ulong startNodeId,
            LinkedList<ulong> nodesToProcess
        )
        {
            nodesToProcess.Clear();

            foreach (var node in nodes.Values)
            {
                node.SetCost(float.PositiveInfinity);
                node.ClearPreviousNode();
            }

            var startNode = nodes[startNodeId];
            startNode.SetCost(0f);

            nodesToProcess.AddFirst(startNodeId);
        }

        private void CalculatePath
        (
            IReadOnlyDictionary<ulong, Node> nodes,
            ulong endNodeId,
            LinkedList<ulong> nodesToProcess
        )
        {
            while (nodesToProcess.Count > 0)
            {
                var currentNodeId = nodesToProcess.First.Value;

                // если дошли до целевой ноды, значит нет смысла дальше вычислять веса
                if (currentNodeId == endNodeId)
                    return;

                var currentNode = nodes[currentNodeId];
                var edges = currentNode.Edges;

                foreach (var edge in edges)
                {
                    Node nextNode;

                    if (edge.StartNode == currentNode)
                        nextNode = edge.EndNode;
                    else
                        nextNode = edge.StartNode;

                    var edgeCost = edge.Cost;
                    var newCost = currentNode.Cost + edgeCost;

                    if (nextNode.Cost <= newCost)
                        continue;

                    nextNode.SetCost(newCost);
                    nextNode.SetPreviousNode(currentNode);

                    AddNodeToLinkedList(nodes, nextNode, nodesToProcess);
                }

                nodesToProcess.RemoveFirst();
            }
        }

        private List<ulong> CollectPath(IReadOnlyDictionary<ulong, Node> nodes, ulong startNodeId, ulong endNodeId)
        {
            var result = new List<ulong>();

            var sNode = nodes[endNodeId];
            result.Add(sNode.Id);
            while (sNode.PreviousNode != null)
            {
                if (sNode.Id == startNodeId)
                {
                    result.Add(sNode.Id);
                    break;
                }

                sNode = sNode.PreviousNode;
                result.Add(sNode.Id);
            }

            result.Reverse();

            return result;
        }

        /// <summary>
        /// Добавить вершину в связный список
        /// </summary>
        /// <param name="nodes">Коллекция всех вершин</param>
        /// <param name="nodeToAdd">Вершина, которую необходимо добавить</param>
        /// <param name="linkedList">Связный список, в который необходимо добавить вершину</param>
        private void AddNodeToLinkedList
        (
            IReadOnlyDictionary<ulong, Node> nodes,
            Node nodeToAdd,
            LinkedList<ulong> linkedList
        )
        {
            var listNode = linkedList.First;

            while (listNode != null)
            {
                if (_counter < 0)
                    return;
                var listNodeCost = nodes[listNode.Value].Cost;

                if (nodeToAdd.Cost < listNodeCost)
                {
                    linkedList.AddBefore(listNode, nodeToAdd.Id);
                    break;
                }

                listNode = listNode.Next;
            }

            linkedList.AddLast(nodeToAdd.Id);
        }
    }
}