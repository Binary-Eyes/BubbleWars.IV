using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace BinaryEyes.Common.MenuItems
{
    /// <summary>
    /// Provides users with an easy way to open some of Unity's common folders.
    /// </summary>
    public static class OpenCommonFolder
    {
        [MenuItem("Eyeviation/Editor/Open Directory/Persistent Data Path", false, -90_000)]
        public static void PersistentDataPath() => OpenOrCreate(Application.persistentDataPath);

        [MenuItem("Eyeviation/Editor/Open Directory/Console Log Path")]
        public static void ConsoleLogPath() => OpenFile(Application.consoleLogPath);

        [MenuItem("Eyeviation/Editor/Open Directory/Data Path")]
        public static void DataPath() => OpenOrCreate(Application.dataPath);

        [MenuItem("Eyeviation/Editor/Open Directory/Streaming Assets Path")]
        public static void StreamingAssetsPath() => OpenOrCreate(Application.streamingAssetsPath);

        [MenuItem("Eyeviation/Editor/Open Directory/Temporary Cache Path")]
        public static void TemporaryCachePath() => OpenOrCreate(Application.temporaryCachePath);

        [MenuItem("Eyeviation/Editor/Open Directory/Default Cache Path")]
        public static void DefaultCachePath() => OpenOrCreate(Caching.defaultCache.path);

        private static void OpenFile(string path)
        {
            if (File.Exists(path))
                Process.Start(path);
        }

        private static void OpenOrCreate(string directory)
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            Process.Start(directory);
        }
    }
}
