using System;
using UnityEngine;
using UnityEngine.Events;

namespace BinaryEyes.Common.Data
{
    [CreateAssetMenu(menuName = "Eyeviation/Events/Scriptable Event", fileName = "[Event]", order = -100_000)]
    [Serializable]
    public sealed class ScriptableEvent
        : ScriptableObject, IEvent
    {
        [SerializeField] private UnityEvent<object> _invoked;

        public void Invoke(object sender)
            => _invoked?.Invoke(sender);

        public void RemoveAllListeners()
            => _invoked?.RemoveAllListeners();

        public void RemoveListener(UnityAction<object> handler)
            => _invoked?.RemoveListener(handler);

        public void AddListener(UnityAction<object> handler)
            => _invoked?.AddListener(handler);
    }


    [Serializable]
    public class ScriptableEvent<T>
        : ScriptableObject, IEvent<T> where T : EventArgs
    {
        [SerializeField] private UnityEvent<object, T> _invoked;

        public void Invoke(object sender, T args)
            => _invoked?.Invoke(sender, args);

        public void RemoveAllListeners()
            => _invoked?.RemoveAllListeners();

        public void RemoveListener(UnityAction<object, T> handler)
            => _invoked?.RemoveListener(handler);

        public void AddListener(UnityAction<object, T> handler)
            => _invoked?.AddListener(handler);
    }
}