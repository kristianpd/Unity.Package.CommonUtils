using System;
using System.Collections.Generic;
using UnityEngine;

namespace Trackman
{
    public interface IMonoBehaviour
    {
        #region Properties
        MonoBehaviour MonoBehavior => this.As<MonoBehaviour>();
        Transform Transform => MonoBehavior.transform;
        GameObject GameObject => MonoBehavior.gameObject;
        #endregion
    }

    public interface IMonoBehaviourInjectable : IMonoBehaviour
    {
    }

    public interface IMonoBehaviourCollectionItem : IMonoBehaviour
    {
    }

    public interface ISingletonInjectable : IMonoBehaviour
    {
    }

    public interface IClassName
    {
        #region Properties
        string ClassName { get; }
        #endregion
    }

    public interface ISingletonInterface : IClassName, IMonoBehaviour
    {
        #region Properties
        string Status => string.Empty;
        bool Testable => false;
        #endregion

        #region Methods
        void InitializeForTests() => throw new NotSupportedException();
        #endregion
    }

    public interface IPrefs : IDictionary<string, object>
    {
        #region Methods
        bool Contains(string path);
        void Write(string path, object value);
        T Read<T>(string path, T defaultValue = default);
        #endregion
    }

    public interface IEvent
    {
        #region Properties
        int Order => 0;
        bool CanExecute => true;
        #endregion
    }
}