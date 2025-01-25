using BinaryEyes.Common.Data;
using BinaryEyes.Common.Enums;
using UnityEngine;

namespace BinaryEyes.Common.Components
{
    /// <summary>
    /// The ComponentEvent behaviour is responsible for invoking an event at a
    /// particular state of the owning component's lifecycle.
    /// </summary>
    public class ComponentEvent
        : MonoBehaviour
    {
        public enum ComponentStateType{Awake,Start,OnEnable,OnDisable,OnDestroy}
        [SerializeField] private Boolean _destroyOnInvoke;
        [SerializeField] private ComponentStateType _target;
        [SerializeField] private EventField _stateReached;
        public IEvent StateReached => _stateReached;
        public ComponentStateType Target => _target;
        private void Awake() => TryInvoke(ComponentStateType.Awake);
        private void Start() => TryInvoke(ComponentStateType.Start);
        private void OnEnable() => TryInvoke(ComponentStateType.OnEnable);
        private void OnDisable() => TryInvoke(ComponentStateType.OnDisable);
        private void OnDestroy() => TryInvoke(ComponentStateType.OnDestroy);
        
        private void TryInvoke(ComponentStateType state)
        {
            if (state != _target)
                return;

            _stateReached.Invoke(this);
            if (_destroyOnInvoke == Boolean.True)
                Destroy(this);
        }
    }
}
