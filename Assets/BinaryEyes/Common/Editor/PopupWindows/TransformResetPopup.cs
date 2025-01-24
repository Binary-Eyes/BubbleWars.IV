using BinaryEyes.Common.Extensions;
using UnityEditor;
using UnityEngine;

namespace BinaryEyes.Common.Windows
{
    public class TransformResetPopup
        : EditorWindow
    {
        [MenuItem("Eyeviation/Editor/Popups/Transform Reset", priority = -100_000)]
        public static void Toggle()
        {
            var mousePosition = GUIUtility.GUIToScreenPoint(Event.current.mousePosition);
            var window = CreateInstance<TransformResetPopup>();
            window.position = new Rect(mousePosition.x, mousePosition.y, 250, 150);
            window.ShowPopup();
        }

        public const string ResetPositionKey = "reset_position";
        public const string ResetRotationKey = "reset_rotation";
        public const string ResetScaleKey = "reset_scale";
        private bool _folded = true;
        private string _requestedAction;
        private void OnLostFocus() => Close();

        private void OnGUI()
        {
            _folded = EditorGUILayout.BeginFoldoutHeaderGroup(_folded, "Transform Reset");
            if (_folded)
            {
                ShowActionRequest("Position");
                ShowActionRequest("Rotation");
                ShowActionRequest("Scale");
            }

            EditorGUILayout.EndFoldoutHeaderGroup();
            TryPerformActionRequest(_requestedAction);
        }

        private void TryPerformActionRequest(string action)
        {
            if (string.IsNullOrEmpty(action))
                return;
            
            Undo.RecordObjects(Selection.objects, action);
            foreach (var transform in Selection.transforms)
            {
                switch (action)
                {
                    case ResetPositionKey: transform.SetLocalPosition(Vector3.zero); break;
                    case ResetRotationKey: transform.SetLocalAngles(Vector3.zero); break;
                    case ResetScaleKey: transform.SetLocalScale(Vector3.one); break;
                }
            }

            Close();
        }

        private void ShowActionRequest(string label)
        {
            var pressed = GUILayout.Button(label, "Button");
            if (pressed)
                _requestedAction = $"reset_{label.ToLower()}";
        }
    }
}