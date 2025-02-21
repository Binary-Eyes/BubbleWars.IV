﻿using UnityEditor;
using UnityEngine;

namespace BinaryEyes.Common.MenuItems
{
    public static class ClearPlayerPrefs
    {
        [MenuItem("Binary Eyes/Editor/Clear PlayerPrefs")]
        public static void Perform()
        {
            Debug.Log("Clearing PlayerPrefs");
            PlayerPrefs.DeleteAll();
        }
    }
}
