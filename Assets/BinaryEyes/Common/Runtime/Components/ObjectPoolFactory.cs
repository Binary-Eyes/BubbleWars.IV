using BinaryEyes.Common.Data;
using BinaryEyes.Common.Extensions;
using UnityEngine;

namespace BinaryEyes.Common.Components
{
    /// <summary>
    /// The ObjectPoolFactory behaviour is responsible for creating new instances
    /// of objects set in the object pool.
    /// </summary>
    public sealed class ObjectPoolFactory
        : MonoBehaviour
    {
        [SerializeField] private GameObjectPool _pool;
        public IInstancePool Pool => _pool;

        private void Awake()
        {
            _pool.Maximize();
            _pool.Instances.ForEachInvoke(entry => entry.SetActive(false));
        }

        public void CreateInstance(Transform source)
        {
            var instance = _pool.Generate();
            instance.transform.position = source.position;
            instance.transform.forward = source.forward;
            instance.SetActive(true);
        }
    }
}