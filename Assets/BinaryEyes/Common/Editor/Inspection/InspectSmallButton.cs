using UnityEngine;

namespace BinaryEyes.Common.Inspection
{
    public static class InspectSmallButton
    {
        public static bool Plus() => Perform("+");
        public static bool Minus() => Perform("-");
        public static bool Exclamation() => Perform("!");
        public static bool Question() => Perform("?");
        public static bool Left() => Perform("<");
        public static bool Right() => Perform(">");

        public static bool Perform(Texture image)
            => GUILayout.Button(image, GUILayout.Width(20.0f), GUILayout.Height(16.5f));

        public static bool Perform(string label)
            => GUILayout.Button(label, GUILayout.Width(20.0f), GUILayout.Height(16.5f));
    }
}
