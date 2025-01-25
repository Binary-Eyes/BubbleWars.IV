using UnityEditor;

namespace BinaryEyes.Common.MenuItems
{
    /// <summary>
    /// The ToggleSelectedGameObject class creates a menu item in the editor.
    /// This item allows users to toggle the active state of all selected game
    /// objects in the scene.
    /// </summary>
    public static class ToggleSelectedGameObjects
    {
        [MenuItem("Binary Eyes/Scene/Toggle Game Objects")]
        public static void Perform()
        {
            Undo.RecordObjects(Selection.objects, "toggle_game_objects");
            foreach (var entry in Selection.gameObjects)
                entry.SetActive(!entry.activeSelf);
        }
    }
}
