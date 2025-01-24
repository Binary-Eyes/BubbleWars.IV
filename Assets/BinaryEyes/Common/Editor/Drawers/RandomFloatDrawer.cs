using BinaryEyes.Common.Data;
using UnityEditor;
using UnityEngine;

namespace BinaryEyes.Common.Drawers
{
    [CustomPropertyDrawer(typeof(RandomFloat))]
    public class RandomFloatDrawer
        : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;
            if (indent > 0)
                position.x += 15.0f*indent;

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            if (indent > 0)
                position.x -= 15.0f*indent;

            var rect = new Rect(position.x, position.y, position.width*0.45f, position.height);
            EditorGUI.PropertyField(rect, property.FindPropertyRelative("Base"), GUIContent.none);
            rect = new Rect(rect.x + rect.width + 3.0f, position.y, position.width*0.05f - 3.0f, position.height);
            EditorGUI.LabelField(rect, "~");

            rect = new Rect(rect.x + rect.width, position.y, position.width*0.5f, position.height);
            EditorGUI.PropertyField(rect, property.FindPropertyRelative("Mod"), GUIContent.none);

            EditorGUI.EndProperty();
            EditorGUI.indentLevel = indent;
        }
    }
}
