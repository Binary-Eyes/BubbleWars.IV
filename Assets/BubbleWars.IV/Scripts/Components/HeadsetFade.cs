using System.Collections;
using BinaryEyes.Common.Attributes;
using BinaryEyes.Common.Enums;
using BinaryEyes.Common.Extensions;
using UnityEngine;
using Event = BinaryEyes.Common.Data.Event;

namespace BubbleWarsEp4.Components
{
    public sealed class HeadsetFade
        : MonoBehaviour
    {
        [SerializeField] [ReadOnlyField] private Renderer _renderer;
        [SerializeField] [ReadOnlyField] private OpacityEffectState _state;
        [SerializeField] private Event _turningTransparent;
        [SerializeField] private Event _turningOpaque;
        [SerializeField] private float _fadeTime;
        public OpacityEffectState State => _state;
        private Coroutine _process;
        private LTDescr _tween;
        private void Awake() => _renderer = GetComponent<Renderer>();
        private void Start() => ForceOpaque();

        [ContextMenu("Force Opaque")]
        public void ForceOpaque()
        {
            _state = OpacityEffectState.Opaque;
            _renderer.material.SetColorAlpha(1.0f);
            _turningOpaque.Invoke(this);
        }

        [ContextMenu("Force Transparent")]
        public void ForceTransparent()
        {
            _state = OpacityEffectState.Transparent;
            _renderer.material.SetColorAlpha(0.0f);
            _turningTransparent.Invoke(this);
        }

        [ContextMenu("Turn Opaque")]
        public Coroutine TurnOpaque()
        {
            if (_state is OpacityEffectState.Opaque or OpacityEffectState.TurningOpaque)
                return _process;

            LeanTween.cancelAll(gameObject);
            _process = this.CancelCoroutine(_process);
            _tween = null;
            _state = OpacityEffectState.TurningOpaque;
            _turningOpaque.Invoke(this);
            return _process = StartCoroutine(PerformTurningOpaque());
        }

        [ContextMenu("Turn Transparent")]
        public Coroutine TurnTransparent()
        {
            if (_state is OpacityEffectState.Transparent or OpacityEffectState.TurningTransparent)
                return _process;

            LeanTween.cancelAll(gameObject);
            _process = this.CancelCoroutine(_process);
            _tween = null;
            _state = OpacityEffectState.TurningTransparent;
            _turningTransparent.Invoke(this);
            return _process = StartCoroutine(PerformTurningTransparent());
        }

        private IEnumerator PerformTurningTransparent()
        {
            _tween = LeanTween.alpha(gameObject, 0.0f, _fadeTime*_renderer.material.color.a);
            yield return new WaitWhile(() => LeanTween.isTweening(_tween.uniqueId));

            _state = OpacityEffectState.Transparent;
        }

        private IEnumerator PerformTurningOpaque()
        {
            var distance = 1.0f - _renderer.material.color.a;
            _tween = LeanTween.alpha(gameObject, 1.0f, _fadeTime*distance);
            yield return new WaitWhile(() => LeanTween.isTweening(_tween.uniqueId));

            _state = OpacityEffectState.Opaque;
        }
    }
}