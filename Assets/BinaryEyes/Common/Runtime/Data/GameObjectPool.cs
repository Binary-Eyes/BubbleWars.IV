using System;
using System.Collections.Generic;
using BinaryEyes.Common.Extensions;
using UnityEngine;
using Object = UnityEngine.Object;

namespace BinaryEyes.Common.Data
{
    [Serializable]
    public sealed class GameObjectPool
        : IInstancePool
    {
        [SerializeField] private GameObject _template;
        [SerializeField] private int _max;
        [SerializeField] private EventField<PoolEntryCreation> _generated;
        private readonly List<GameObject> _instances = new();
        public IEvent<PoolEntryCreation> Generated => _generated;
        public GameObject Template => _template;
        public int Max => _max;
        public int CurrentCount => _instances.Count;
        public IReadOnlyList<GameObject> Instances => _instances;
        public int NextIndex { get; private set; } = -1;

        public GameObject Generate()
        {
            NextIndex = (NextIndex + 1) % Max;
            if (NextIndex >= CurrentCount)
                _instances.Add(Instantiate());

            var instance = _instances[NextIndex];
            instance.SetActive(true);

            _generated.Invoke(this, new PoolEntryCreation(instance));
            return instance;
        }

        public void Maximize()
        {
            var count = Max - CurrentCount;
            for (var i = 0; i < count; i++)
                _instances.Add(Instantiate());
        }

        private GameObject Instantiate()
            => Object.Instantiate(_template).SetName(_template.name);
    }
}