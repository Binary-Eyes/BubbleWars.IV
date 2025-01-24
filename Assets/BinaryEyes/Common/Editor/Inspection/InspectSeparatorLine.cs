using System;
using UnityEditor;
using UnityEngine;

namespace BinaryEyes.Common.Inspection
{
    public static class InspectSeparatorLine
    {
        public static void FullSeparation() => Perform(LineFlags.WithStartSpace | LineFlags.WithEndSpace);
        public static void WithStartSpace() => Perform(LineFlags.WithStartSpace);
        public static void WithEndSpace() => Perform(LineFlags.WithEndSpace);

        public static void Perform(LineFlags flags = LineFlags.None)
        {
            if (flags.HasFlag(LineFlags.WithStartSpace))
                EditorGUILayout.Space(1.5f);

            GUI.enabled = false;
            EditorGUILayout.TextField("", GUILayout.Height(6.0f));
            GUI.enabled = true;

            if (flags.HasFlag(LineFlags.WithEndSpace))
                EditorGUILayout.Space(1.5f);
        }

        [Flags]
        public enum LineFlags
        {
            None = 0,
            WithStartSpace = 1 << 0,
            WithEndSpace = 1 << 1
        }
    }
}
