using System;
using Sirenix.OdinInspector;
using UnityEngine;

public abstract class ScriptableSingleton<T> : SerializedScriptableObject where T : SerializedScriptableObject
{
	protected static string FileName
	{
		get
		{
			return typeof(T).Name;
		}
	}

	public static T Instance
	{
		get
		{
			if (ScriptableSingleton<T>.cachedInstance == null)
			{
				ScriptableSingleton<T>.cachedInstance = (Resources.Load(ScriptableSingleton<T>.FileName) as T);
			}
			if (ScriptableSingleton<T>.cachedInstance == null)
			{
				Debug.LogWarning("No instance of " + ScriptableSingleton<T>.FileName + " found, using default values");
				ScriptableSingleton<T>.cachedInstance = ScriptableObject.CreateInstance<T>();
			}
			return ScriptableSingleton<T>.cachedInstance;
		}
	}

	public static bool DoesInstanceExist
	{
		get
		{
			if (ScriptableSingleton<T>.cachedInstance == null)
			{
				ScriptableSingleton<T>.cachedInstance = (Resources.Load(ScriptableSingleton<T>.FileName) as T);
			}
			return ScriptableSingleton<T>.cachedInstance != null;
		}
	}

	private static T cachedInstance;
}
