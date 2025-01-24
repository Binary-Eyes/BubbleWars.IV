using System;
using System.Collections.Generic;
using UnityEngine;

namespace BinaryEyes.Common
{
    /// <summary>
    /// The InstancePool class is used to manage a limited pool of instances of
    /// a particular target object. Instead of creating and destroying instances
    /// on demand, the InstancePool class creates a fixed number of instances up
    /// front and keeps them in a pool for reuse.
    /// </summary>
    public interface IInstancePool
    {
        IEvent<PoolEntryCreation> Generated { get; }
        GameObject Template { get; }
        int Max { get; }
        int CurrentCount { get; }
        IReadOnlyList<GameObject> Instances { get; }
    }

    [Serializable]
    public sealed class PoolEntryCreation
        : EventArgs
    {
        public readonly GameObject Instance;

        public PoolEntryCreation(GameObject instance)
            => Instance = instance;
    }
}