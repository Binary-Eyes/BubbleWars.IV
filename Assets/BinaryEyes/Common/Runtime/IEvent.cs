using System;
using UnityEngine.Events;

namespace BinaryEyes.Common
{
    public interface IEvent
    {
        void RemoveAllListeners();
        void RemoveListener(UnityAction<object> handler);
        void AddListener(UnityAction<object> handler);
    }

    public interface IEvent<T>
        where T : EventArgs
    {
        void RemoveAllListeners();
        void RemoveListener(UnityAction<object, T>  handler);
        void AddListener(UnityAction<object, T> handler);
    }
}