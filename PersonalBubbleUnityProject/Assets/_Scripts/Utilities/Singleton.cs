using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

/// <summary>
/// A single static Instance references to an instance of a class.
/// New instances will override the current reference
/// </summary>
public abstract class StaticInstance<T> : MonoBehaviourPunCallbacks where T : MonoBehaviourPunCallbacks
{
    public static T Instance { get; private set; }
    protected virtual void Awake() => Instance = this as T;

    protected virtual void OnApplicationQuit()
    {
        Instance = null;
        Destroy(gameObject);
    }
}

/// <summary>
/// A single static Instance references to an instance of a class.
/// New instances will be destroyed to keep the original reference intact
/// </summary>
public abstract class Singleton<T> : StaticInstance<T> where T : MonoBehaviourPunCallbacks
{
    protected override void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        else base.Awake();
    }
}

/// <summary>
/// A single static Instance references to an instance of a class.
/// New instances will be destroyed to keep the original reference intact.
/// And it won't be destroyed when loading a new scene
/// </summary>
public abstract class PersistentSingleton<T> : Singleton<T> where T : MonoBehaviourPunCallbacks
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}