using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class GridGeneratorWindow : EditorWindow
    {
        private const float LayoutSpace = 10f;
        
        private Vector3 _gridSize = new (0, 0, 0);
        private int _padding = 1;
        
        private readonly GridGenerator _gridGenerator = new ();
        
        [MenuItem("Tools/Sok/GridGenerator")]
        public static void ShowWindow()
        {
            GetWindow(typeof(GridGeneratorWindow));
        }
        
        private void OnGUI()
        {
            GUILayout.Label("Generate Grid", EditorStyles.boldLabel);

            GUILayout.Space(LayoutSpace);
            _gridSize = EditorGUILayout.Vector3Field("Grid Size", _gridSize);
            _padding = EditorGUILayout.IntField("Padding", _padding);
            GUILayout.Space(LayoutSpace);
            
            if (GUILayout.Button("Generate"))
            {
                _gridGenerator.Generate(_gridSize, _padding);
            }
        }
    }
}
