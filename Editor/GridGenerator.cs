using System.Collections.Generic;
using UnityEngine;

namespace Editor
{
    public class GridGenerator
    {
        private const string ParentName = "Grid";
        private const string NodeName = "Node";
        
        public void Generate(Vector3 gridSize, float padding)
        {
            var parent = new GameObject(ParentName);
            var gridVisualization = parent.AddComponent<GridVisualization>();
            
            for (var i = 0; i < gridSize.z; i++)
            {
                for(var j = 0; j < gridSize.y; j++)
                {
                    for(var k= 0; k < gridSize.x; k++)
                    {
                        var nodePosition = new Vector3(k, j, i) * padding;
                        var nodeName = $"{NodeName}_{i}_{j}_{k}";

                        var node = CreateNode(nodePosition, parent, nodeName);
                        
                        var gridData = new GridData(new List<NodeData>(), gridSize);
                        gridData.Nodes.Add(new NodeData(node.transform));
                        
                        gridVisualization.GridData = gridData;
                    }
                }
            }
        }
        
        private GameObject CreateNode(Vector3 nodePosition, GameObject parent, string nodeName)
        {
            var node = new GameObject(nodeName)
            {
                transform =
                {
                    position = nodePosition
                }
            };
            node.AddComponent<NodeVisualization>();
            node.transform.SetParent(parent.transform);

            return node;
        }
    }
}