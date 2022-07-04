using InventorySystem.InventorySerialization;
using UnityEditor;
using UnityEngine;

namespace Personal.InventoryPackage.Editor
{
    public class InventoryManagementWindow : EditorWindow
    {

        InventoryInitializationData _initializationData;
        
        [MenuItem("Window/InventoryManagement")]
        static void ShowWindow()
        {
            var window = GetWindow<InventoryManagementWindow>();
            window.titleContent = new GUIContent("Inventory Management");
            window.Show();
        }

        private void OnGUI()
        {
            EditorGUILayout.ObjectField("Teste Initialization Data", _initializationData,
                typeof(InventoryInitializationData), false);

            if (_initializationData != null)
            {
                EditorGUILayout.ObjectField()
            }
        }
    }
}