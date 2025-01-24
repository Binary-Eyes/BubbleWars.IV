using System;
using Debug = UnityEngine.Debug;

namespace BinaryEyes.Core.Extensions
{
    public static class ObjectLogging
    {
        public static T LogWakingUp<T>(this T source) => source.LogMessage("WakingUp");
        public static T LogStarting<T>(this T source) => source.LogMessage("Starting");
        public static T LogEnabling<T>(this T source) => source.LogMessage("Enabling");
        public static T LogInitializing<T>(this T source) => source.LogMessage("Initializing");
        public static T LogDisabling<T>(this T source) => source.LogMessage("Disabling");
        public static T LogDestroying<T>(this T source) => source.LogMessage("Destroying");
        public static T LogDisposing<T>(this T source) => source.LogMessage("Disposing");

        public static void Assert<T>(this T entry, bool condition, string message)
        {
            var text = $"{entry.GetType().Name}::{message}";
            Debug.Assert(condition, text);
        }

        public static T LogMessage<T>(this T entry, string format, params object[] args)
        {
#if UNITY_EDITOR || DEBUG || FORCE_LOG
            Debug.Log(GetMessage(entry, format, args));
#endif
            return entry;
        }

        public static T LogError<T>(this T entry, string format, params object[] args)
        {
#if UNITY_EDITOR || DEBUG || FORCE_LOG
            Debug.LogError(GetMessage(entry, format, args));
#endif
            return entry;
        }

        public static T LogWarning<T>(this T entry, string format, params object[] args)
        {
#if UNITY_EDITOR || DEBUG || FORCE_LOG
            Debug.LogWarning(GetMessage(entry, format, args));
#endif
            return entry;
        }

        public static void LogNullException<T>(this T entry, string format, params object[] args)
        {
            var message = GetMessage(entry, format, args);
            Debug.LogError(message);
            throw new NullReferenceException(message);
        }

        private static string GetMessage<T>(T source, string format, params object[] args)
        {
            var message = string.Format(format, args);
            var text = $"{source.GetType().Name}: {message}";
            var unityObject = source as UnityEngine.Object;
            if (unityObject != null)
                text += $" [{unityObject.name}]";

            return text;
        }
    }
}