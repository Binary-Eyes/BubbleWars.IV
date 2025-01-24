using UnityEditor;
using UnityEngine;

namespace BinaryEyes.Common.Inspection
{
    public static  class InspectScriptRef
    {
        public static void Perform(SerializedObject target)
        {
            var previousGuiState = GUI.enabled;
            GUI.enabled = false;
            EditorGUILayout.PropertyField(target.FindProperty("m_Script"));
            GUI.enabled = previousGuiState;
        }
    }
}
