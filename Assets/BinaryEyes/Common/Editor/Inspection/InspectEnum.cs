using System;
using UnityEditor;

namespace BinaryEyes.Common.Inspection
{
    public static class InspectEnum
    {
        public static T Perform<T>(string label, T value) where T : Enum
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException($"inspected value type is not an enum: type={typeof(T).Name}");

            return (T)EditorGUILayout.EnumPopup(label, value);
        }
    }
}
