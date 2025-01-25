using System;
using System.Collections;
using BinaryEyes.Common.Data;
using UnityEngine;
using Boolean = BinaryEyes.Common.Enums.Boolean;

namespace BinaryEyes.Common.Components
{
    /// <summary>
    /// The TimedEvent behaviour is responsible for invoking a particular event
    /// X seconds after being enabled.
    /// </summary>
    public class TimedEvent
        : MonoBehaviour
    {
        [SerializeField] private Boolean _destroyOnInvoke;
        [SerializeField] private float _time;
        [SerializeField] private EventField<TimerTick> _timerTicked;
        [SerializeField] private EventField _timerFinished;
        public IEvent TimerFinished => _timerFinished;
        public IEvent<TimerTick> TimerTicked => _timerTicked;
        private void OnEnable() => StartCoroutine(TimedInvoke());

        private IEnumerator TimedInvoke()
        {
            var timeLeft = _time;
            while (timeLeft > 0.0f)
            {
                _timerTicked.Invoke(this, new TimerTick(timeLeft, _time));
                yield return null;
                
                timeLeft -= Time.deltaTime;
            }

            _timerTicked.Invoke(this, new TimerTick(0.0f, _time));
            _timerFinished.Invoke(this);
            
            if (_destroyOnInvoke == Boolean.True)
                Destroy(this);
        }
    }

    [Serializable]
    public sealed class TimerTick
        : EventArgs
    {
        public readonly float CurrentTime;
        public readonly float MaxTime;

        public TimerTick(float currentTime, float maxTime)
        {
            CurrentTime = currentTime;
            MaxTime = maxTime;
        }
    }
}
