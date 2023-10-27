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

        for (var i = 0; i < _gridSize.z; i++)
        {
            for (var j = 0; j < _gridSize.y; j++)
            {
                for (var k = 0; k < _gridSize.x; k++)
                {
                    if (k + 1 < _gridSize.x)
                    {
                        Gizmos.DrawLine(_nodes[k, j, i].transform.position, _nodes[k + 1, j, i].transform.position);  
                    }
                    if(j + 1 < _gridSize.y)
                    {
                        Gizmos.DrawLine(_nodes[k, j, i].transform.position, _nodes[k, j + 1, i].transform.position);  
                    }
                    if(i + 1 < _gridSize.z)
                    {
                        Gizmos.DrawLine(_nodes[k, j, i].transform.position, _nodes[k, j, i + 1].transform.position);  
                    }
                }
            }
        }
    }
}