using System.Collections.Generic;

public class GraphPath
{
    public List<GraphNode> Nodes = new();

    public void AddNode(GraphNode node) => Nodes.Add(node);
}