using UnityEditor;
using UnityEngine.UI;

namespace BinaryEyes.Common.ContextMenu
{
    public static class ButtonClickContext
    {
        [MenuItem("CONTEXT/Button/Click")]
        public static void Perform(MenuCommand command)
        {
            var button = (Button)command.context;
            button.onClick.Invoke();
        }
    }
}