using UnityEditor;
using UnityEngine;

namespace BinaryEyes.Common.Inspection
{
    public static class InspectObject
    {
        public static T WithoutSceneObjects<T>(string label, T value) where T : Object
            => Perform(label, value, false);

        public static T WithSceneObjects<T>(string label, T value) where T : Object
            => Perform(label, value, true);

        public static T Perform<T>(string label, T value, bool allowSceneObjects) where T : Object
            => (T)EditorGUILayout.ObjectField(label, value, typeof(T), allowSceneObjects);
    }
}
