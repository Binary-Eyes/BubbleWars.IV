using BinaryEyes.Common.Extensions;
using UnityEngine;

namespace BinaryEyes.Common.Components
{
    /// <summary>
    /// The QuitOnEsc behaviour allows users to easily quit the application by
    /// pressing the 'esc' key or the 'back' key on an android device.
    /// </summary>
    public class QuitOnEscape
        : MonoBehaviour
    {
        public void PerformQuit()
        {
            this.LogMessage("Quitting");
            enabled = false;
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
#endif
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                PerformQuit();
        }
    }
}