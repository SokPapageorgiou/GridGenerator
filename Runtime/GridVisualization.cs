using System.Linq;
using UnityEngine;

public class GridVisualization : MonoBehaviour
{
    private NodeVisualization[,,] _nodes;
    private Vector3 _gridSize;

    public void Init(Vector3 gridSize)
    { 
        _gridSize = gridSize;
        _nodes = new NodeVisualization[(int) gridSize.x,(int) gridSize.y,(int) gridSize.z];
    }
    
    public void AddNode(Vector3 index, NodeVisualization nodeVisualization) 
        => _nodes[(int) index.x, (int) index.y, (int) index.z] = nodeVisualization;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        var linesToDraw = 
            from i in Enumerable.Range(0, (int)_gridSize.z)
            from j in Enumerable.Range(0, (int)_gridSize.y)
            from k in Enumerable.Range(0, (int)_gridSize.x)
            let currentNode = _nodes[k, j, i]
            from neighbor in new[] { (k + 1, j, i), (k, j + 1, i), (k, j, i + 1) }
            where neighbor.Item1 < _gridSize.x && neighbor.Item2 < _gridSize.y && neighbor.Item3 < _gridSize.z
            let neighborNode = _nodes[neighbor.Item1, neighbor.Item2, neighbor.Item3]
            select new { Start = currentNode, End = neighborNode };

        foreach (var line in linesToDraw)
        {
            DrawLine(line.Start, line.End);
        }
    }
    
    private void DrawLine(NodeVisualization from, NodeVisualization to) 
        => Gizmos.DrawLine(from.transform.position, to.transform.position);
}