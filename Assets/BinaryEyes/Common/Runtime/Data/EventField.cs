using System;
using UnityEngine;
using UnityEngine.Events;

namespace BinaryEyes.Common.Data
{
    [Serializable]
    public sealed class EventField
        : IEvent
    {
        [SerializeField] private ScriptableEvent _external;
        [SerializeField] private Event _inScene;

        public void Invoke(object sender)
        {
            _inScene.Invoke(sender);
            if (_external != null) 
                _external.Invoke(sender);
        }

        public void RemoveAllListeners()
            => _inScene.RemoveAllListeners();

        public void RemoveListener(UnityAction<object> handler)
            => _inScene.RemoveListener(handler);

        public void AddListener(UnityAction<object> handler)
            => _inScene.AddListener(handler);

        public void RemoveAllListenersOnProjectEvent()
        {
            if (_external != null)
                _external.RemoveAllListeners();
        }

        public void RemoveListenerOnProjectEvent(UnityAction<object> handler)
        {
            if (_external != null)
                _external.RemoveListener(handler);
        }

        public void AddListenerOnProjectEvent(UnityAction<object> handler)
        {
            if (_external != null)
                _external.AddListener(handler);
        }
    }

    [Serializable]
    public class EventField<T>
        : IEvent<T> where T : EventArgs
    {
        [SerializeField] private ScriptableEvent<T> _external;
        [SerializeField] private Event<T> _inScene;

        public void Invoke(object sender, T args)
        {
            _inScene.Invoke(sender, args);
            if (_external != null)
                _external.Invoke(sender, args);
        }

        public void RemoveAllListeners()
            => _inScene.RemoveAllListeners();

        public void RemoveListener(UnityAction<object, T> handler)
            => _inScene.RemoveListener(handler);

        public void AddListener(UnityAction<object, T> handler)
            => _inScene.AddListener(handler);

        public void RemoveAllListenersOnProjectEvent()
        {
            if (_external != null)
                _external.RemoveAllListeners();
        }

        public void RemoveListenerOnProjectEvent(UnityAction<object, T> handler)
        {
            if (_external != null)
                _external.RemoveListener(handler);
        }

        public void AddListenerOnProjectEvent(UnityAction<object, T> handler)
        {
            if (_external != null)
                _external.AddListener(handler);
        }
    }
}