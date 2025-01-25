using BinaryEyes.Common.Attributes;
using BinaryEyes.Common.Data;
using UnityEngine;

namespace BinaryEyes.Common.Components
{
    /// <summary>
    /// The CounterEvent behaviour will invoke its event once a specific counter
    /// value has been reached.
    /// </summary>
    public class CounterEvent
        : MonoBehaviour
    {
        [SerializeField] [ReadOnlyField] private int _current;
        [SerializeField] private int _target;
        [SerializeField] private EventField _countReached;
        public IEvent CountReached => _countReached;
        public int Target => _target;
        public int Current => _current;
        public void ResetCounter() => _current = 0;

        public void IncrementCounter()
        {
            _current += 1;
            if (_current < _target)
                return;

            _current = 0;
            _countReached.Invoke(this);
        }
    }
}
