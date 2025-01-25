using BinaryEyes.Common.Extensions;
using UnityEditor;

namespace BinaryEyes.Common.MenuItems
{
    /// <summary>
    /// The ResetSelectedTransform menu item allows users to easily reset the
    /// local data of all selected transforms in the scene.
    /// </summary>
    public static class ResetSelectedTransforms
    {
        [MenuItem("Binary Eyes/Scene/Reset Selected Transforms")]
        public static void Perform()
        {
            Undo.RecordObjects(Selection.objects, "reset_selected_transforms");
            foreach (var transform in Selection.transforms)
                transform.ResetLocal();
        }
    }
}
