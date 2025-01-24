using System;
using System.Collections.Generic;
using BinaryEyes.Common;
public delegate T OnMissingEntry<out T>(IReadOnlyContext source);

namespace BinaryEyes.Common
{
    /// <summary>
    /// The IReadOnlyContext interface describes the public operations of a
    /// context object which are guaranteed not to modify the internal state
    /// of the context object.
    /// </summary>
    public interface IReadOnlyContext
    {
        int EntryCount { get; }
        bool Contains(string key);
        T GetEntry<T>(string key, OnMissingEntry<T> onMissing = null);
        object GetEntry(string key, OnMissingEntry<object> onMissing = null);
    }

    /// <summary>
    /// The IContext interface describes all public operations provided by
    /// a particular context object. A context object allows users to easily
    /// map specific values for required operations.
    /// </summary>
    public interface IContext
        : IReadOnlyContext
    {
        IContext PopEntry(string key, out object target);
        IContext RemoveEntry(string key);
        IContext SetEntry(string key, object value);
        IContext AddEntry(string key, object value);
    }

    /// <summary>
    /// The Context object provides the eyeviation-sdk's default implementation
    /// of a context.
    /// </summary>
    public sealed class Context
        : IContext
    {
        public int EntryCount => _items.Count;

        public bool Contains(string key)
            => _items.ContainsKey(key);

        public T GetEntry<T>(string key, OnMissingEntry<T> onMissing = null)
        {
            if (_items.TryGetValue(key, out var entry))
                return (T)entry;

            if (onMissing != null)
                return onMissing.Invoke(this);

            throw new InvalidOperationException($"requested entry is missing: {key}");
        }

        public object GetEntry(string key, OnMissingEntry<object> onMissing = null)
        {
            if (_items.TryGetValue(key, out var entry))
                return entry;

            if (onMissing != null)
                return onMissing.Invoke(this);

            throw new InvalidOperationException($"requested entry is missing: {key}");
        }

        public IContext PopEntry(string key, out object target)
        {
            _items.Remove(key, out target);
            return this;
        }

        public IContext RemoveEntry(string key)
        {
            _items.Remove(key);
            return this;
        }

        public IContext SetEntry(string key, object value)
        {
            _items[key] = value;
            return this;
        }

        public IContext AddEntry(string key, object value)
        {
            _items.Add(key, value);
            return this;
        }

        private readonly Dictionary<string, object> _items = new();
    }
}