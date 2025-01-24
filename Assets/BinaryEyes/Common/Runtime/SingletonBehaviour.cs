using System;
using BinaryEyes.Common.Extensions;
using UnityEngine;

namespace BinaryEyes.Common
{
    /// <summary>
    /// The SingletonBehaviour component provides a simple base for implementing
    /// the 'singleton' design pattern using a Unity3D scene component. Please
    /// think long and hard before creating and using singletons given that they
    /// introduce hardcoded dependencies which are difficult to manage and change.
    /// </summary>
    public class SingletonBehaviour<T>
        : MonoBehaviour where T : SingletonBehaviour<T>
    {
        public static T Instance { get; private set; }
        public static bool Exists => Instance;

        public static T GetInstance()
        {
            if (Instance)
                return Instance;

            throw new NullReferenceException($"failed to locate singleton instance: type={typeof(T).Name}");
        }


        protected virtual void Awake()
        {
            this.LogWakingUp();
            ValidateSingletonInstance();
            Instance = (T)this;
        }

        private void ValidateSingletonInstance()
        {
            if (!Instance)
                return;

            if (Instance == this)
                return;

            var msg = $"{typeof(T).Name}: singleton instance already exist [{name}]";
            throw new InvalidOperationException(msg);
        }
    }
}