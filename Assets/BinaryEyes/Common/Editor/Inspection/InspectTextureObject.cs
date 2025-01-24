using UnityEditor;
using UnityEngine;

namespace BinaryEyes.Common.Inspection
{
    public static class InspectTextureObject
    {
        public static Texture2D Perform(string label, Texture2D texture)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel(label);
            var output = (Texture2D)EditorGUILayout.ObjectField(texture, typeof(Texture2D), false);
            EditorGUILayout.EndHorizontal();

            return output;
        }
    }
}
