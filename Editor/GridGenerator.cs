using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class GridGenerator : EditorWindow
    {
        private const string ParentName = "Grid";
        private const string NodeName = "Node";
        
        private Vector3 _gridSize = new (0, 0, 0);
        private int _padding = 1;
        
        [MenuItem("Tools/Sok/GridGenerator")]
        public static void ShowWindow()
        {
            GetWindow(typeof(GridGenerator));
        }
        
        private void OnGUI()
        {
            GUILayout.Label("Generate Grid", EditorStyles.boldLabel);

            _gridSize = EditorGUILayout.Vector3Field("Grid Size", _gridSize);
            _padding = EditorGUILayout.IntField("Padding", _padding);
            
            if (GUILayout.Button("Generate"))
            {
                GenerateGrid();
            }
        }

        private void GenerateGrid()
        {
            var parent = new GameObject(ParentName);
            
            for (var i = 0; i < _gridSize.z; i++)
            {
                for(var j = 0; j < _gridSize.y; j++)
                {
                    for(var k= 0; k < _gridSize.x; k++)
                    {
                        var nodePosition = new Vector3(k * _padding, j * _padding, i * _padding);
                        var nodeName = $"{NodeName}_{i}_{j}_{k}";
                        
                        AddNode(nodePosition, parent, nodeName);
                    }
                }
            }
        }

        private void AddNode(Vector3 nodePosition, GameObject parent, string nodeName)
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
        }
    }
}
