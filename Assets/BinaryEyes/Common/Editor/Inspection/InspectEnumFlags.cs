using System;
using UnityEditor;

namespace BinaryEyes.Common.Inspection
{
    public static class InspectEnumFlags
    {
        public static T Perform<T>(string label, T value) where T : Enum
            => (T) EditorGUILayout.EnumFlagsField(label, value);
    }
}
