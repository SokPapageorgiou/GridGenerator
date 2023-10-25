using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Editor
{
    public class GridGenerator : EditorWindow
    {
        private const string ParentName = "Grid";
        private const string NodeName = "Node";
        
        private Vector3 _gridSize = new (0, 0, 0);
        
        [MenuItem("Tools/Sok/GridGenerator")]
        public static void ShowWindow()
        {
            GetWindow(typeof(GridGenerator));
        }
        
        private void OnGUI()
        {
            GUILayout.Label("Generate Grid", EditorStyles.boldLabel);
            
            _gridSize = EditorGUILayout.Vector3Field("Grid Size", _gridSize);

            if (GUILayout.Button("Generate"))
            {
                Debug.Log(_gridSize);
                GenerateGrid();
            }
        }

        private void GenerateGrid()
        {
            var parent = new GameObject(ParentName);
            
            var totalNodes = _gridSize.x + _gridSize.y + _gridSize.z;
            
            Debug.Log(totalNodes);
            
            for (var i = 0; i < totalNodes; i++)
            {
                var node = new GameObject($"{NodeName}_{i}");
                node.transform.SetParent(parent.transform);
            }
        }
    }
}
