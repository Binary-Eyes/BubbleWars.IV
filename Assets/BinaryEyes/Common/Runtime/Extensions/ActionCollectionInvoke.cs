using System;
using System.Collections.Generic;

namespace BinaryEyes.Common.Extensions
{
    public static class ActionCollectionInvoke
    {
        public static void Invoke(this List<Action> actions)
        {
            for (var i = actions.Count - 1; i >= 0; i--)
            {
                actions[i]?.Invoke();
                if (actions[i] == null)
                    actions.RemoveAt(i);
            }
        }

        public static void Invoke<T>(this List<Action<T>> actions, T value)
        {
            for (var i = actions.Count - 1; i >= 0; i--)
            {
                actions[i]?.Invoke(value);
                if (actions[i] == null)
                    actions.RemoveAt(i);
            }
        }
    }
}