using System.Linq;
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
            gridVisualization.Init(gridSize);
            
            var nodesToAdd = 
                from i in Enumerable.Range(0, (int)gridSize.z)
                from j in Enumerable.Range(0, (int)gridSize.y)
                from k in Enumerable.Range(0, (int)gridSize.x)
                let nodeIndex = new Vector3(k, j, i)
                let nodePosition = nodeIndex * padding
                let nodeName = $"{NodeName}_{i}_{j}_{k}"
                select (NodeIndex: nodeIndex, NodePosition: nodePosition, NodeName: nodeName);

            foreach (var nodeData in nodesToAdd)
            {
                var node = CreateNode(nodeData.NodePosition, parent, nodeData.NodeName);
                gridVisualization.AddNode(nodeData.NodeIndex, node);
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