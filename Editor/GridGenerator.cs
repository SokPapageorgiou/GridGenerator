using UnityEngine;

namespace Editor
{
    public class GridGenerator
    {
        private const string ParentName = "Grid";
        private const string NodeName = "Node";

        private Vector3[][][] _nodes;
        
        public void Generate(Vector3 gridSize, float padding)
        {
            var parent = new GameObject(ParentName);
            var gridVisualization = parent.AddComponent<GridVisualization>();
            gridVisualization.Init(gridSize);
            
            
            for (var i = 0; i < gridSize.z; i++)
            {
                for(var j = 0; j < gridSize.y; j++)
                {
                    for(var k= 0; k < gridSize.x; k++)
                    {
                        var nodeIndex = new Vector3(k, j, i);
                        var nodePosition = nodeIndex * padding;
                        var nodeName = $"{NodeName}_{i}_{j}_{k}";

                        var node = CreateNode(nodePosition, parent, nodeName);
                        gridVisualization.AddNode(nodeIndex, node);
                    }
                }
            }
        }
        
        private NodeVisualization CreateNode(Vector3 nodePosition, GameObject parent, string nodeName)
        {
            var node = new GameObject(nodeName)
            {
                transform =
                {
                    position = nodePosition
                }
            };
            node.transform.SetParent(parent.transform);
            return node.AddComponent<NodeVisualization>();
        }
    }
}